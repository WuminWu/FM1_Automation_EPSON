'
' FM1 Automation Project
' First Robot
' by IAC Wumin
'

#define DEBUG_LOG "debugMode"

Double angle, fixedAngle, positionX, positionY, fixedPositionX, fixedPositionY
String getString$, NewString$, Status$
Integer striperReady, placeWhichWindow, ErrorCount


Function main
	
	Power High
	Speed 100, 80, 50
    Accel 100, 30, 100, 50, 100, 10
    
	Xqt getAngleService
	Xqt getPositionService
	Print "Xqt all servers"
	
	placeWhichWindow = 1
		
	Double VariationAngle1, VariationAngle2         ' variation between from TakeShot and Stick, and I need to add it to result
	VariationAngle1 = CU(Stick1) - CU(TakeShot)     ' for window#1
    VariationAngle2 = CU(Stick2) - CU(TakeShot)     ' for window#2

	Print "VariationAngle1 = ", VariationAngle1
	Print "VariationAngle2 = ", VariationAngle2

	Home

' Position one
' Suck Antenna up

	Do
		Jump P0                                 ' Pick Antenna up from Stripper
		Wait 0.1
		On SuckerOne                            ' Turn on Sucker
		Wait 0.1

' Position Two
' Adjust Angle of Antenna 		

		Go P1
		Call cameraNotifocation                 ' Inform Supervisor to take a Pic and return a fixed angle variation
		Wait 0.5
		
		fixedAngle = angle                      ' Get a angle of variation from getAngleService
		Print "P1 = ", P1
		Print "Fix angle = ", fixedAngle
		Go Here +U(fixedAngle)                  ' Rotate angle 
		Print "Adjust p1 =  : ", Here
		Wait 0.1
		
		
' Position Two		
' Adjust Offset of Antenna

		Call cameraNotifocation2                 ' Inform Supervisor to take a Pic and return fixed varition of X and Y 
		
		fixedPositionX = positionX               ' Get X and Y's variation from getPositionService
		Wait 0.1                                 ' Note : Need a delay to save variable
		fixedPositionY = positionY
		Print "Adjust X : ", fixedPositionX
		Print "Adjust Y : ", fixedPositionY
		Go Here +X(fixedPositionX) +Y(fixedPositionY)
		Print "Adjust p1' =  : ", Here

' Position Three
' Place Antenna on Window

		Select placeWhichWindow
			
			Case 1                                                                 ' To place winodw position one
				Jump P2 +X(fixedPositionX) +Y(fixedPositionY) +U(fixedAngle)
				Off SuckerOne
				placeWhichWindow = 2
				Print "Adjust p2 = ", Here
				Wait 0.1

			Case 2                                                                 ' To place winodw position Two
				Jump P3 +X(fixedPositionX) +Y(fixedPositionY) +U(fixedAngle)
				Off SuckerOne
				placeWhichWindow = 1
				Print "Adjust p3 = ", Here
				Wait 0.1
			
			Default
				Print "ERROR : placeWhichWindow is not chosen"
				Pause
		Send
	Loop
Fend

Function main1
	
	Power High
	Speed 100, 100, 20
    Accel 100, 30, 100, 100, 100, 100
    
	Call cameraCalibration
	
Fend

Function main2
	Power High
	Speed 100, 100, 50
    Accel 100, 30, 100, 100, 100, 10
    'Speed 100, 100, 100
    'Accel 100, 100, 100, 100, 100, 100
    
    Pallet 1, P5, P6, P7, P8, 3, 7
	Integer i
    
    Home
    Do
    	For i = 1 To 19 Step +2
		    Jump P0
		    Wait 0.1
		    Jump P1
		    Wait 0.1
		    Jump P2
		    Wait 0.1
	    
			Jump Pallet(1, i)
	    
		    Jump P0
		    Wait 0.1
		    Jump P1
		    Wait 0.1
		    Jump P3
		    Wait 0.1
		    
		    Jump Pallet(1, i + 1)
	    Next i
    Loop
Fend

Function main3

	Power High
	Speed 80, 50, 50
    Accel 100, 30, 100, 100, 100, 10
		
	Pallet 1, P5, P6, P7, P8, 3, 7
	Integer i
	
	For i = 1 To 21
		Jump Pallet(1, i)
	Next
	
	
Fend

Function main4

	Power High
	Speed 80, 80, 50
    Accel 100, 50, 100, 10, 100, 50
    
    Do
    	Jump SuckAntenna
    	Jump Pallet1
    Loop
    
Fend

Function main5
	' Test MessageLoop
	
	Xqt getAngleService           '#201
	Xqt getPositionService        '#202
	Print "Xqt all servers"
	
Fend

Function main6

Fend

Function main7
	
Fend

Function init
	Print "This is FM1 Antenna Sticking Automation"
	If Motor = Off Then
		Motor On
	EndIf
	SLock
	Reset
	
Fend


Function cameraCalibration
	
	Jump TakeShot
	Call cameraNotifocation          ' Inform Supervisor to take a Sec Pic
		
	Wait 1
	' X moves 4 times
	Go Here +X(0.001)
	Wait 1
	Go Here +X(0.003)
	Wait 1
	Go Here +X(0.005)
	Wait 1
	Go Here +X(0.007)
	Wait 1
	
	' Y moves 4 times
	Go Here +Y(0.001)
	Wait 1
	Go Here +Y(0.003)
	Wait 1
	Go Here +Y(0.005)
	Wait 1
	Go Here +Y(0.007)
	Wait 1
	
			
	fixedPositionX = positionX                        ' the variation of X
	fixedPositionY = positionY                        ' the variation of Y
	Print Here
	
	Go Here +X(fixedPositionX) +Y(fixedPositionY)
	Here TakeShot                                   ' replace TakeShot with new position
		
	MemOff canTakePicture
	
Fend


Function getAngleService
	OpenNet #201 As Server                   ' ip = 192.168.0.3 , port = 2000
	WaitNet #201
	
	Do
		If ChkNet(201) > 0 Then
			Print "Here is getAngleService"
			Input #201, angle
			Print angle

			Print #201, "Got Angle"
		EndIf
	Loop
	CloseNet #201
	Print "CloseNet #201 Angle"
Fend

Function getPositionService
	OpenNet #202 As Server                   'ip = 192.168.0.3 , port = 2001
	WaitNet #202
	Integer count
	count = 0
	positionX = 0
	positionY = 0
	
	Do
		If ChkNet(202) > 0 And count = 0 Then
			Print "Here is getPositionService"
			Input #202, positionX
            Print "X = ", positionX
			count = 1
			Print #202, "Got PositionX"
		EndIf
		
		If ChkNet(202) > 0 And count = 1 Then
			Input #202, positionY
			Print "Y = ", positionY
			count = 0
			Print #202, "Got PositionY"
		EndIf
	Loop
	CloseNet #202
	Print "CloseNet #202 Position"
Fend

Function getStringService
	OpenNet #203 As Server
	WaitNet #203
	Print "Connection of getString is fine"

	Do
		If ChkNet(203) > 0 Then
			Input #203, getString$
			Print getString$
			
			Print #203, "Got String"
			Print "String Send Feedback"
		Else
			'Print "Nothing Recieved"
		EndIf
	Loop
	CloseNet #203
	Print "CloseNet #203 String"
Fend

Function cameraNotifocation
	
	'Port: #215
	'Host Name: 192.168.0.2
	'TCP/IPPort: 36000
	
	Print "Here is Client #215"
	OpenNet #215 As Client
	WaitNet #215
	Print #215, "TakePictureForAngle"
	CloseNet #215
	
Fend

Function cameraNotifocation2
	
	'Port: #215
	'Host Name: 192.168.0.2
	'TCP/IPPort: 36000
	
	Print "Here is Client #215"
	OpenNet #215 As Client
	WaitNet #215
	Print #215, "TakePictureForPosituon"
	CloseNet #215
	
Fend

