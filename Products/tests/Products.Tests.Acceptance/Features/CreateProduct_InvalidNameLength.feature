Feature: Create a New Product with Invalid Name Length
        As a user of the system
        I want to be prevented from creating a product with an invalid name length
        So that only valid product names are allowed

    @invalidNameLength
    Scenario: Failing to create a product with a name that is too short
        Given I have the following product details:
          | Name | Quantity | Price | Description         |
          | A    | 5        | 49.99 | Invalid name length |
        When I attempt to create the product
        Then the system should reject the product
        And I should see an error message indicating the name length is invalid

    @invalidNameLength
    Scenario: Failing to create a product with a name that is too long
        Given I have the following product details:
          | Name                                          | Quantity | Price | Description         |
          | ThisIsAnExtremelyLongProductNameThatIsInvalid | 5        | 49.99 | Invalid name length |
        When I attempt to create the product
        Then the system should reject the product
        And I should see an error message indicating the name length is invalid