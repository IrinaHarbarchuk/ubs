Feature: UbsNavigationUI

In order to verify that all 'Navigation' works properly on UBS website
I want to run these tests

Background: 
Given I have opened UBS website

@ui @regression 
Scenario Outline: clicking on a specific menu item redirects user to the desired page
When I click on '<MenuItem>' menu item under '<MenuTab>' menu tab
Then I can see that page with title '<Title>' is displayed 
Examples:
| MenuTab           | MenuItem    | Title       |
| Wealth Management | Our service | Our service |
| Asset Management  | About us    | About us    |
| Investment Bank   | In focus    | In focus    |
| About us          | Media       | Media       |
| Careers           | Search jobs | Search jobs |
