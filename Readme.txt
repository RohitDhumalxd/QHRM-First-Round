QHRM First Round

i have used Microsoft Visal Studio 2019 
============================================================================================================

	To Run Application just Need to open " WebTest.sin " file Inside folder WebTest 

============================================================================================================

Step 1--> a> Create Database "QHRM" 
  	    b> Crete Table in sql Server --> 
	 create  table Products(id int primary key,Name varchar(255),Description varchar(255),Price decimal);

Step 2 --> After Creating web Application 
		Install the Dapper package by running the following command: Install-Package Dapper

		Install the Microsoft SQL Server package by running the following command:
				 Install-Package Microsoft.EntityFrameworkCore.SqlServer


Step 3--> if You Have Your Own Database just change Server "Name" & Database "Name"

"ConnectionStrings": {
    "DefaultConnection": "Server=ROHIT;Database=QHRM;Trusted_Connection=True;MultipleActiveResultSets=true"
  }

