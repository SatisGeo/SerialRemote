# SerialRemote
This is an example application to control SatisGeo PMG-2 remotely using the USB serial port. 

![Application Window](/doc/app.png)

This is an example application to control SatisGeo PMG-2 remotely using the USB serial port. 
To use this application, the PMG-2 firmware version must be 4.08.r and higher, and remote mode must first be enabled. To enable it, go to the MEASURE menu and select REMOTE, then connect a USB cable. The PMG-2 will connect to the PC as a USB serial port.
Set the serial port number in the application and connect to the device. The Mode and Tune settings will update according to the current device settings. The Mode and Tune settings can be changed and written to the PMG-2 by clicking the Set button. 
To run the measurement, click on the Measure button. The result is then shown in the application in a similar way to how it is shown on the device.

# The Code
There are two main classes: Form1 and PMG2Serial. Form 1 is the main window class, and PMG2Serial encapsulates all PMG-2 remote commands, including documentation.
