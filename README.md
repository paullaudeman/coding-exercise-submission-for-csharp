# Coding Screen

You are working with a large Fortune 500 client on their Advanced Proprietary Pizza Logistics Engine (APPLE).

The client has collected a dataset `Data.json` on it's 2000 employees and wants to figure out a few VERY IMPORTANT statistics.

Requirements: Write an application (C#, F#, JavaScript, or PowerShell) that outputs the following three data points:

- Which department has the largest number of employees who like Pineapple on their pizzas? 

- How many pizzas would you need to order to feed the Engineering department, assuming a pizza feeds 4 people? Ignore personal preferences.

- Which pizza topping combination is the most popular in each department and how many employees prefer it?

Please spend no more than 1 hour on this challenge. If you do not complete all three tasks in about an hour, include a few sentences about your approach or things you would do differently, given more time.

(Credit to Olo's 'pizza test' for inspiring this challenge with a twist.)

----

# Paul's notes on the Coding Exercise submission

The attached code sample is a .net Framework console application. I removed the "packages" folder to minimize the size of the zip. Visual Studio should pull the Newtonsoft Json.NET package down for you automatically but please let me know if you run into any trouble building it. You should be able to build and run the executable by passing in a filename at the command prompt (or by running it through Visual Studio, the data.json will be copied to your bin directory and I supply the name of it in the project properties/debug page).

A couple more thoughts -- 

• If this were a closer to a real-world project, I'd also seek to learn more about the expected volume of data. For example, would we normally be working with a data set of thousands of records, or millions, etc. If the latter, loading this all into memory and querying through linq would probably not be the most efficient solution (versus perhaps bcp'ing the data into SQL Server and querying from there). 

• I'd also add in logging (probably using Serilog or NLog or whichever suite you prefer) and alerting. 

Lastly, I'd like to thank you for the opportunity to try this code quiz. Please let me know if you have any further questions. 