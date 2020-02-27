Feature: GetInTouchPageUI
In order to verify that I can successfully submit 'Get In Touch'
I want to run these tests

Background: 
Given I have opened UBS website

@regression
Scenario: Verify that validation messages are displayed on UBS website when I submit 'Get in touch' form with empty data
And I go to 'Get in touch' url on UBS website
When I click on 'Submit' button on UBS website
Then I can see that validation messages are displayed on UBS website near all obligatory fields
