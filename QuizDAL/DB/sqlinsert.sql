/*INSERT INTO Theme([name]) VALUES('C#.NET'),('JS'),('C++'),('HTML/CSS'),('Linear algebra'),('Design patterns');*/
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

INSERT INTO Question([name],themeId) VALUES
('What is the Array.filter for?',2),
('What will this code output? if(function f(){}) {alert(typeof f);}',2),
('What happens when you add true + false?',2),
('Which of these words has no special use in JavaScript, not mentioned in any way in the standard?',2),
('What is equals 2 && 1 && null && 0 && undefined ??',2),
('What will this code output? alert( 20e-1["toString"](2) );',2),
('Choose a correct ternary operator',2),
('What will this code output? alert(1/0)',2),
('Where is the launch of the pop-up window correctly indicated?',2),
('What is difference before a ECMAScript and JavaScript?',2);

INSERT INTO Answer([name],questionId,isCorrect) VALUES
('Select items for someone filter',11,1),
('Sort items by someone filter',11,0),
('Group items by someone filter',11,0),
('Transform all items by someone filter',11,0),
('Nan',12,0),
('undefined',12,1),
('null',12,0),
('0',12,0),
('1',12,0),
('0',13,0),
('truefalse',13,0),
('1',13,1),
('undefined',13,0),
('volatile',14,0),
('using',14,1),
('debugger',14,0),
('1',15,0),
('0',15,0),
('null',15,1),
('undefined',15,0),
('10',16,1),
('20',16,0),
('1',16,0),
('2',16,0),
('x : 0 ? x>2',17,0),
('x ? 0 : x>2',17,0),
('x>2 ? x : 0',17,1),
('x>2 : x ? 0',17,0),
('null',18,0),
('undefined',18,0),
('infinity',18,1),
('Nan',18,0),
('console.log("text")',19,0),
('alert("text")',19,1),
('document.write("text")',19,0),
('JavaScript - language, ECMAScript - specification',20,1),
('JavaScript - specification, ECMAScript - language',20,0),
('it`s the same things',20,0);

INSERT INTO Question([name],themeId) VALUES
('What means * operator (in not arithmetical context)?',3),
('Which of these casts don"t exists in C++',3),
('What will this code output? bool x=11, std::cout<<x',3),
('Choose correct purpose of destructor',3),
('What means "auto" keyword?',3),
('how to add a comment?',3),
('How many parameters can be passed to the destructor?',3),
('How many arguments can be passed to a function?',3),
('How to include the standard iostream library?',3),
('What is the size of the "empty" object in bytes?',3);

INSERT INTO Answer([name],questionId,isCorrect) VALUES
('Pointer',21,1),
('Reference',21,0),
('Degree',21,0),
('interpret_cast',22,0),
('static_cast',22,0),
('auto_cast',22,1),
('const_cast',22,0),
('1',23,1),
('true',23,0),
('0',23,0),
('false',23,0),
('11',23,0),
('Method that executes before object destroying',24,1),
('Method that executes after object creating',24,0),
('Destructors doesn"t exists in C++',24,0),
('dynamic string',25,0),
('automation type detection',25,1),
('pointer to void',25,0),
('//',26,1),
('#',26,0),
('@',26,0),
('/*',26,0),
('3',27,0),
('2',27,0),
('1',27,0),
('0',27,1),
('50',28,0),
('unlimited',28,1),
('100',28,0),
('150',28,0),
('#define <iostream>',29,0),
('#include <iostream.h>',29,0),
('#define <iostream.h>',29,0),
('#include "iostream.h"',29,0),
('1',30,1),
('2',30,0),
('3',30,0),
('4',30,0),
('5',30,0);

INSERT INTO Question([name],themeId) VALUES
('What difference between px and % measure?',4),
('What means a "div"?',4),
('What difference between absolute and relative positions?',4),
('Which button declaration is correct?',4),
('How to enable js script?',4),
('How to display object "A" under object "B" with z-index?',4),
('What means "flexbox"?',4),
('Which event we need to process for a click?',4),
('What difference between <th> and <td>?',4),
('How to display "div" centered relative to horizontal?',4);

INSERT INTO Answer([name],questionId,isCorrect) VALUES
('1 - pixel measure, 2 - percentage measure for current screen',32,1),
('1 - pixel measure, 2 - percentage measure for default screen size which equals 1920x1080',32,0),
('it"s the same things',32,0),
('division operation',33,0),
('section in HTML-document',33,1),
('animation timing',33,0),
('absolute doesn"t depends by parent element, relative depends by parent element',34,1),
('relative doesn"t depends by parent element, absolute depends by parent element',34,0),
('none of the variants are correct',34,0),
('<checkbox id="check-accept"/>',35,0),
('<input type="checkbox" id="check-accept">',35,1),
('<input type="checkbox" onchange="changeButtonCondition()" id="check-accept"></input>',35,0),
('<JS src="js/script.js"></JS>',36,0),
('<script src="js/script.js"></script>',36,1),
('<script src="js/script.js"/>',36,0),
('A z-index should be greater than B z-index',37,1),
('A z-index should be less than B z-index',37,0),
('A z-index should be equals B z-index',37,0),
('one-dimensional layout method for arranging items in rows',38,0),
('one-dimensional layout method for arranging items in columns',38,0),
('one-dimensional layout method for arranging items in rows or columns',38,1),
('click',39,0),
('onclick',39,1),
('with-click',39,0),
('<th> text value is bolder then <td> text value',40,1),
('<td> text value is bolder then <th> text value',40,0),
('it"s the same things',40,0),
('margin:auto',41,1),
('left:auto;right:auto',41,0),
('margin-left:auto;margin-right:auto',41,0);

INSERT INTO Question([name],themeId) VALUES
('What are relational databases?',5),
('What does the query look like to display ALL values ​​from the "Orders" table"?',5),
('What data will we get from this request? select id, date, customer_name from Orders;',5),
('Is there an error? select id, date, customer_name from Orders where customer_name = Mike;',5),
('What will show: select * from Orders where date between "2017-01-01" and "2017-12-31"',5),
('What is wrong with this request select id, date from Orders where seller_id = NULL;',5),
('The order of execution of the AND and OR operators is as follows:',5),
('What the following query will show: select DISTINCT seller_id order by seller_id from Orders;',5),
('Choose the correct example of using the CONCAT function:',5),
('Choose the correct example of using the ROUND function',5);

INSERT INTO Answer([name],questionId,isCorrect) VALUES
('A database in which information is stored in the form of two-dimensional tables linked together',42,1),
('Database with one unrelated table',42,0),
('A collection of unrelated data',42,0),
('select * from Orders;',43,1),
('select % from Orders;',43,0),
('select ALL from Orders;',43,0),
('Unsorted numbers and dates of all orders with customer names',44,1),
('None, the query was made incorrectly',44,0),
('Numbers and dates of all orders with customer names, sorted by the first column',44,0),
('Query is correct',45,0),
('Mike must be written in quotation marks',45,1),
('Swap the line with "where" with "from"',45,0),
('None, the query was made incorrectly',46,0),
('All data on orders made in 2017',46,1),
('All data for orders made in 2017, except for December 31, 2017',46,0),
('NULL must be enclosed in quotes',47,0),
('Comparison with NULL can only be done with the IS operator',47,1),
('Comparison with NULL can only be done with the ON operator',47,0),
('First AND then OR',48,1),
('First OR then AND',48,0),
('All variants are correct',48,0),
('Unique seller IDs sorted in ascending order',49,0),
('Unique seller IDs sorted in descending order',49,0),
('Nothing, the query is incorrect, ORDER BY is always placed at the end of the query',49,1),
('select concat = index and city from Orders;',50,0),
('select concat IN (`index`, `city`) from Orders;',50,0),
('select concat(`index`," ", `city`) from Orders;',50,1),
('select id, price * discount AS total price from Orders ROUND (2);',51,0),
('select id, price * discount ROUND (2) AS total price from Orders;',51,0),
('select id, ROUND (price * discount, 2) AS total price from Orders;',51,1);