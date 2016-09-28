Feature:
    In order to check payroll calculation
    As a payroll user
    I want to test payroll first example

@mytag
Scenario: Payroll for employment
    Given Payroll process for payroll period 01 2016
    And   Employee works in Weekly schedule 40 hours
    And   Employee has 0 hours of absence
    And   Employee Salary is CZK 12345 monthly
    And   Employee Bonus is 33 percent from CZK 98765
    And   Meal Deduction is CZK 321
    When  Payroll process calculate results
    Then  Contribution to Health insurance should be CZK 2023
    And   Contribution to Social insurance should be CZK 2921
    And   Tax advance before tax relief on payer should be CZK 9045
    And   Tax relief on payer should be CZK 2070
    And   Tax advance should be CZK 6975
    And   Gross income should be CZK 44937
    And   Netto income should be CZK 33018
    And   Netto payment should be CZK 32697
