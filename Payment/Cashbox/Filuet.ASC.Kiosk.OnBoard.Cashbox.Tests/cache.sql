BEGIN TRANSACTION;

CREATE TABLE IF NOT EXISTS `Planograms` (
	`Id`	BLOB NOT NULL UNIQUE,
	`Data`	TEXT NOT NULL,
	`Timestamp`	DateTime NOT NULL,
	PRIMARY KEY(`Id`)
);

CREATE TABLE IF NOT EXISTS `CashPaymentDetails` (
	`Id`	BLOB NOT NULL UNIQUE,
	`Amount`	decimal NOT NULL,
	`Result`	TEXT NOT NULL,
	`Type`	TEXT NOT NULL,
	`Timestamp`	DateTime NOT NULL,
	PRIMARY KEY(`Id`)
)

COMMIT;
