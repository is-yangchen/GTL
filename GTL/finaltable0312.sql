create table OPERATELOG(
	operate varchar(100) not null,
	CurrentTime datetime not null,
	Device_Id varchar(10) not null,
	direction varchar(5) not null
)

create table OP(
	OP_current1 float,
	OP_current2 float,
	OP_current3 float,
	OP_current4 float,
	OP_barcode varchar(10),
	OP_state int NOT NULL,
	CurrentTime datetime not null,
	Device_Id varchar(10) not null,
)

create table MB(
	MB_current1 float,
	MB_current2 float,
	MB_current3 float,
	MB_current4 float,
	MB_barcode varchar(10),
	MB int NOT NULL,
	CurrentTime datetime not null,
	Device_Id int NOT NULL 
)

Create table HAC_TMPMOD( 
    HAC_TH_Temperature1 int NOT NULL , 
    HAC_TH_Temperature2 int NOT NULL , 
    HAC_TH_Temperature3 int NOT NULL , 
    HAC_TH_Humidity1 int NOT NULL , 
    HAC_TH_Humidity2 int NOT NULL ,
	HAC_State int NOT NULL, 
    CurrentTime datetime NOT NULL , 
	Device_Id varchar(10) not null,
 )
 
 Create table HAC_ENGINE(
 	  HAC_State int NOT NULL,  
      HAC_Motor_Text_Speed int NOT NULL , 
      HAC_Motor_Elecspeed int NOT NULL , 
	  HAC_Motor_Power int NOT NULL,
      CurrentTime datetime NOT NULL , 
	  Device_Id varchar(10) not null,
 )

 Create table HAC_OD(
 	  HAC_State int NOT NULL,  
      HAC_X int NOT NULL , 
      HAC_Y int NOT NULL , 
      HAC_OD int NOT NULL , 
      CurrentTime datetime NOT NULL , 
	  Device_Id varchar(10) not null,
 )


 create table HAC_LUMIN(
      HAC_State int NOT NULL, 
      CurrentTime datetime NOT NULL , 
	  Device_Id varchar(10) not null,
	  HAC_Addr	int,
	  HAC_Lumin	int,	
	  HAC_X	int,
	  HAC_Y	int,
	  HAC_Pwm int
)

 create table HAC_BARCODE(
      CurrentTime datetime NOT NULL , 
      Device_Id varchar(10) not null, 
	  HAC_Inbarcode varchar(10) NOT NULL,
	  HAC_Outbarcode varchar(10) NOT NULL
)

create table HAC_STATE(
	  CurrentTime datetime NOT NULL , 
	  Device_Id varchar(10) not null,
	  HAC_State int
) 

create table MMR_INFO(
	  CurrentTime datetime NOT NULL , 
	  Device_Id varchar(10) not null,
	  MMR_Serial int,
	  MMR_Temperature int,
	  MMR_PH float,
	  MMR_Oxygen float
)

create table LPS_LIQUID(
	CurrentTime datetime NOT NULL , 
      	Device_Id varchar(10) NOT NULL,
        LPS_Source varchar(20) NOT NULL,
	LPS_Target varchar(20) NOT NULL,
	LPS_Quantity int NOT NULL,
	LPS_Includespeed int,
	LPS_Excludespeed int,
	LPS_Include int NOT NULL,
	LPS_Exclude int NOT NULL
)

create table LPS_SETTING(
	  CurrentTime datetime NOT NULL , 
      Device_Id varchar(10) NOT NULL,
	  LPS_Setting varchar(20) NOT NULL
)