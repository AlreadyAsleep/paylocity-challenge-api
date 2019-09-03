# paylocity-challenge-api
The api for the Paylocity coding challenge

## Requirements
One of the critical functions that we provide for our clients is the ability to pay for their employees’
benefits packages. A portion of these costs are deducted from their paycheck, and we handle that
deduction. Please demonstrate how you would code the following scenario:
- The cost of benefits is $1000/year for each employee
- Each dependent (children and possibly spouses) incurs a cost of $500/year
- Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

We’d like to see this calculation used in a web application where employers input employees and their
dependents, and get a preview of the costs.
This is of course a contrived example. We want to know how you would implement the application
structure and calculations and get a brief preview of how you work.
Please implement a web application based on these assumptions:
- All employees are paid $2000 per paycheck before deductions
- There are 26 paychecks in a year

## Solution Overview
I solved this problem by implementing a ASP.NET Web API that can be used to create employees and dependents and calculate their annual costs of benefits pursuant to the requirements stated above. These employees and their dependents are then stored in a SQL database so they can be easily retrieved by the user later. While this feature wasn't explicitly required, it made solving this problem easier as applying a discount or benefit rate to an employee or dependent a sql join as opposed to having to query for the benefit and discount rates and apply them in the business layer. 

## Project Structure
The project is layed out in typical N-Tier fashion, with a service layer for the API, DI containier, and view logic, a business layer, a data layer that also contains the logic for Entity Framework Core, and a Domain object layer. The most important thing to note about this structure is that layers that are below other layers cannot be dependent on the layers above them. For example, a repository in the Data layer cannot depend on code that resides in the Service layer, in fact the Data layer doesn't even have a project reference to the Business or Service layers. This keeps the seperation of concerns between layers rigid and helps developers follow SOLID design principles.  

## Testing 
The unit tests for this project reside in the 'tests' directory. The test project structure mirrors the overall project structure (ex. tests for the Data layer are in the Data.Tests project). 

## Other Thoughts 
There are a few things I excluded from this project I'd like to mention that would be in a typical web application
- There is no notion of a user in the database, so all the employees belong to the same 'user'. Adding a user wouldn't be a difficult thing to do (another table and a key relationship on the employee table) but I wanted to keep things simple since this is an example application
- There is no authentication. Due to the limited time, I decided not to fool with authentication on the API endpoints. Setting up authentication is usually one of those things you just set up once and don't really worry about again, except for putting an attribute over a controller method like ```AdminAuthorize``` etc. Also there is no user so authentication wouldn't make sense.
- There is no logging. Again, keeping things simple due to time constraints. 
