Feature: Login to Newark

Background: 
Given I navigate to the url

Scenario: Login to newark
When I enter valid username and Password
Then I must able to login into the home page
And Verify all the options are displayed correctly