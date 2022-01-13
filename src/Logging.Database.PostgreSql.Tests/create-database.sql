CREATE SCHEMA "Cg";

CREATE TABLE "Cg"."Log" (
	"LogId" uuid NOT NULL,
	"HostName" varchar(100) NOT NULL,
	"UserName" varchar(100) NOT NULL,
	"Category" varchar(400) NOT NULL,
	"Level" varchar(20) NOT NULL,
	"EventId" varchar(400) NULL,
	"ActivityId" varchar(36) NULL,
	"UserId" varchar(36) NULL,
	"LoginName" varchar(100) NULL,
	"ActionId" varchar(36) NULL,
	"ActionName" varchar(400) NULL,
	"RequestId" varchar(36) NULL,
	"RequestPath" varchar(400) NULL,
	"Sql" varchar(4000) NULL,
	"Parameters" varchar(4000) NULL,
	"StateText" varchar(200) NULL,
	"StateProperties" varchar(4000) NULL,
	"ScopeText" varchar(200) NULL,
	"ScopeProperties" varchar(4000) NULL,
	"Text" varchar(500000) NULL,
	"Exception" varchar(500000) NULL,
	"FilePath" varchar(4000) NULL,
	"Time" timestamp NOT NULL,
	CONSTRAINT "PK_Log" PRIMARY KEY ("LogId")
);