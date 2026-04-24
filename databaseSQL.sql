Drop table "Customers";

Create table "Customers" (
	"CustomerId" SERIAL NOT NULL PRIMARY KEY UNIQUE,
	"LastName" varchar(50) NOT NULL,
	"FirstName" varchar(50) NOT NULL,
	"PhoneNumber" varchar(13) UNIQUE,
	"Email" varchar(50) NOT NULL UNIQUE,
	"Address" varchar(250),
	"CreatedTime" Timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
);

select * from "Customers";

INSERT INTO "Customers" ("LastName","FirstName","PhoneNumber","Email","Address") 
	VALUES ('kabiz','ceciz','+905411111111','user@email.com','Ankara Turkiye');


Create table "Vehicles" (
	"VehicleId" SERIAL NOT NULL PRIMARY KEY UNIQUE,
	"CustomerId" INT REFERENCES "Customers"("CustomerId"),
	"Plate" varchar(50) NOT NULL UNIQUE,
	"Brand" varchar(13) NOT NULL,
	"Color" varchar(50) NOT NULL,
	"VIN_Number" varchar(250) NOT NULL UNIQUE,
	"CreatedTime" Timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO "Vehicles" ("CustomerId","Plate","Brand","Color","VIN_Number") 
	VALUES (1,'45DM111','BWM_İ320','Mavi','124UFA451');

select * from "Vehicles";
