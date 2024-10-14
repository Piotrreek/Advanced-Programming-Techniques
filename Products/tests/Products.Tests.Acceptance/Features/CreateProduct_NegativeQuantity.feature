Feature: Create a New Product with Negative Quantity
        As a user of the system
        I want to be prevented from creating a product with a negative quantity
        So that only valid quantities are allowed

    @negativeQuantity
    Scenario: Failing to create a product with a negative quantity
        Given I have the following product details:
          | Name           | Quantity | Price  | Description        |
          | InvalidProduct | -5       | 49.99  | Invalid quantity   |
        When I attempt to create the product
        Then the system should reject the product
        And I should see an error message indicating the quantity is invalid
