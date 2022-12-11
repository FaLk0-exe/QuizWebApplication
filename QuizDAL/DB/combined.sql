CREATE TABLE Theme(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(100) NOT NULL,
themeDescription NVARCHAR(256) NOT NULL
);

CREATE TABLE Question(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(100) NOT NULL,
themeId INT NOT NULL,
FOREIGN KEY (themeId) REFERENCES Theme(id)
);

CREATE TABLE Answer(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(256) NOT NULL,
isCorrect BIT NOT NULL,
questionId INT NOT NULL,
FOREIGN KEY (questionId) REFERENCES Question(id)
);

CREATE TABLE Result(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
userId NVARCHAR(256) NOT NULL,
completeDate DATETIME NOT NULL,
themeId INT NOT NULL,
correctAnswersCount INT NOT NULL,
FOREIGN KEY (themeId) REFERENCES Theme(id)
);

INSERT INTO Theme([name],themeDescription) VALUES('C#.NET','Quiz about different topics of C#.NET'),
('JS','Quiz about different topics of JS'),
('C++','Quiz about different topics of C++'),
('HTML/CSS','Quiz about different topics of HTML/CSS'),
('Linear algebra','Quiz about different topics of linear algebra'),
('Design patterns','Quiz about different topics of design patterns');
INSERT INTO Question([name],themeId) VALUES
('What is the difference between static, public, and void?',1),
('What means a key word "yield"?',1),
('What is the difference between out and ref parameters?',1),
('What is serialization?',1),
('What is meant by an Abstract Class?',1),
('What are sealed classes in C#?',1),
('What is the difference between Arraylist and Array?',1),
('How can the Array elements be sorted in descending order?',1),
('How to get first element for someone condition in LINQ?',1),
('What means a CLR abbreviature?',1);
INSERT INTO Answer([name],questionId,isCorrect) VALUES
('static - access modifier, public - static member declaration, void - type of return value',1,0),
('static - static member declaration, public - access modifier, void - type of return value',1,1),
('static - access modifier, public - type of return value, void - static member declaration',1,0),
('special keyword for Iterators',2,1),
('this keyword doesnt exists in C#.NET',2,0),
('it`s Linq method',2,0),
('out used for the passing the arguments to methods as a reference type, ref used for the passing the arguments by a reference',3,1),
('ref used for the passing the arguments to methods as a reference type, out used for the passing the arguments by a reference',3,0),
('out used for the passing the arguments to methods as a value type, ref used for the passing the arguments by a reference',3,0),
('out used for the passing the arguments to methods as a reference type, ref used for the passing the arguments to methods as a value type',3,0),
('process of converting a object to data',4,0),
('process of converting a someone object to another object',4,0),
('process of converting a data to object',4,1),
('process of converting a someone data to another data',4,0),
('a class that cannot be instantiated',5,0),
('a restricted class that cannot be used to create objects',5,1),
('it`s the same as interface',5,0),
('a sealed class',5,0),
('Array stores data of the same type whereas ArrayList stores data in the form of the object which may be of different types',7,1),
('ArrayList stores data of the same type whereas Array stores data in the form of the object which may be of different types',7,0),
('it`s the same things',7,0),
('array.Sort(-1)',8,0),
('array.Reverse.Sort()',8,0),
('array.OrderByDescending().Reverse()',8,0),
('array.OrderByDescending()',8,1),
('array.Take(1)',9,0),
('array.First()',9,1),
('array.TakeFirst()',9,0),
('array.GetFirst()',9,0),
('Class library realization',10,0),
('Common library realization',10,0),
('Common language runtime',10,1),
('Class language runtime',10,0);
