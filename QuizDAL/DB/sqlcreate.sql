﻿CREATE TABLE Theme(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(100) NOT NULL,
);

CREATE TABLE Question(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(100) NOT NULL,
themeId INT NOT NULL,
FOREIGN KEY (themeId) REFERENCES Theme(id)
);

CREATE TABLE Answer(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(100) NOT NULL,
isCorrect BIT NOT NULL,
questionId INT NOT NULL,
FOREIGN KEY (questionId) REFERENCES Question(id)
);

CREATE TABLE Result(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
userId NVARCHAR(100) NOT NULL,
completeDate DATETIME NOT NULL,
themeId INT NOT NULL,
correctAnswersCount INT NOT NULL
FOREIGN KEY (themeId) REFERENCES Theme(id)
);