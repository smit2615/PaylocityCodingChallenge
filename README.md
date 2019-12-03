# Paylocity Coding Challenge
This is a sample web application made for the Pyalocity coding challenge. The application allows employers to input their
employees along with their dependents to get a preview of the annual costs of each employee after benefit deductions. 

This application makes these assumptions: 
- Each employee is paid 2000 dollars per pay period
- There are 26 pay periods
- Each employee has a base deduction of 1000 dollars for benefits
- Each dependent increases this deduction by 500 dollars
- The only current rule is that people with first names beginning with the letter A recieve a 10 percent discount on their benefits

## Software Design and Architecture
This app uses a multi-tier architecture that consists of a front-end Angular project and a web API comprised with a business layer
and data layer on the back-end. In an effort to produce software that isn't tightly coupled, each layer is "unaware" of the details 
present in any layer at a higher level than itself. For example, in the arrangement arrangement below, the data layer does not contain 
references to things defined in the domain of the business layer or UI.
> UI --> Web API --> Business Layer --> Data Layer 

## Implementation Methodology
Although this is a sample application, it was built with scalability in mind. In a prodution application, more than one benefit rule
would exist. In order to plan for this, rules are applied via a strategy design pattern in which the strategy contains the logic for
applying a particular rule. Furthermore, this implementation of the rule's application is created using a factory pattern. The idea here 
is to keep the rule logic modularized and make sure it doesn't grow into a massive file or single function. With the application's current
setup, rules can be added by following a few repeatable steps that don't require repeated modifications or additions to the existing 
business layer.

## Local Setup Instructions
- Clone the repository
- Open the PaylocityCodingChallenge folder in VS Code
- Run `ng serve` in the terminal
- Open the web api solution file in Visual Studio
- Build and run the web api
- Open a browser and navigate to localhost:4200


