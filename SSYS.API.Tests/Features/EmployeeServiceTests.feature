Feature: EmployeeServiceTests
As a Developer
I want to add and delete an Employee through API
In order to test their behaviour.

    Background:
        Given the Endpoint https://localhost:7171/api/v1/employees is available

    @employee-adding
    Scenario: Add an Employee with testing data
        When a Post Request is sent
          | Name   | LastName          | Phone     |
          | Carlos | A Sample Employee | 987654321 |
        Then a Response is received with Status 200
        And an Employee Resource is included in Response Body
          | Id | Name   | LastName          | Phone     |
          | 4  | Carlos | A Sample Employee | 987654321 |

    @employee-deleting
    Scenario: Delete an existing Employee
        When a Delete Request is sent
          | Id |
          | 4  |
        Then a esponse is received with Status 200
        And an Employee Resource is included in Response Body
          | Id | Name   | LastName          | Phone     |
          | 4  | Carlos | A Sample Employee | 987654321 |