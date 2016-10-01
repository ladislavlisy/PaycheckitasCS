Feature:
    In order to check payroll calculation
    As a payroll user
    I want to test payroll with multiple examples in table

@mytag
Scenario Outline: Payroll for employment
    Given Payroll process for payroll period <period>
    And   Employee works in Weekly schedule <schedule> hours
    And   Employee has <absence> hours of absence
    And   Employee Salary is CZK <salary> monthly
    And   Employee Bonus is <bonus perc> percent from CZK <bonus base>
    And   Meal Deduction is CZK <deduction>
    When  Payroll process calculate results
    Then  Contribution to Health insurance should be CZK <health ins>
    And   Contribution to Social insurance should be CZK <social ins>
    And   Tax advance before tax relief on payer should be CZK <tax before>
    And   Tax relief on payer should be CZK <payer relief>
    And   Tax advance should be CZK <tax advance>
    And   Gross income should be CZK <gross income>
    And   Netto income should be CZK <netto income>
    And   Netto payment should be CZK <netto payment>
    Examples: Employment with Tax Advance
      | name               | period  | schedule | absence | salary   | bonus base | bonus perc | deduction | health ins | social ins | tax before | payer relief | tax advance | gross income | netto income | netto payment |
      | 01-Employee-Bonus  | 01 2016 | 40       | 0       | 12345    | 98765      | 33         | 321       | 2023       | 2921       | 9045       | 2070         | 6975        | 44937        | 33018        | 32697         |
