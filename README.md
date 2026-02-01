# TOAST-ImportTool


An import tool to convert XML headers at start of motion blocks to textlists for motionrows, so that the MotionRow's text can be imported at design time. This mean the programmer does not have to fill in every field of the text list to produce a motion row.

The tool can import a TwinCAT3 TOAST project, extract the xml from the motions and inserts them into the MotionRow text list for use in the program automaticly. This saves time when using TOAST for TwinCAT3 as no HMI programming is required for any ammount of motions within the limits of TOAST. (6 stations, 99 MotionRows per station).

The tool also can export the names of the motion and assemble the logical message for the 5 fault messages for each station
 - Failed to Advance
 - Failed to Return
 - Lost Advance
 - Lost Return
 - Switch Fault
   

The reason for this tool is to allow PLC/automation software development to go, as i call it "real-fuckin' fast". It should take <10mins to program a basic function for manual mode. It them automates the workflow between manual motions, texts and alarms, and hopefully more things in future.

(Future) export to the prompt list of the station
- Waiting for Clamp Cylinder A1 to Advance...
- Waiting for Clamp Cylinder A1 to Return...


<img width="954" height="666" alt="image" src="https://github.com/user-attachments/assets/15437ba6-9408-4e67-ab17-498314af77bd" />



# Crude image from MS Paint explaining the process of the TOAST-ImportTool
<img width="1552" height="1796" alt="image" src="https://github.com/user-attachments/assets/23dbf01e-bb5b-4415-9688-37fb246bc6ee" />



