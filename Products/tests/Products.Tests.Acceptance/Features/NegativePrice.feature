Feature: Negative Product Price
        As a user of the system
        I want to ensure that product prices are valid
        So that I don't add products with negative prices

    @createProductNegativePrice
    Scenario: Failing to create a product with a negative price
        Given I have the following product details:
          | Name  | Quantity | Price  | Description |
          | ValidName | 5       | -49.99 | A product   |
        When I attempt to create the product
        Then the system should reject the product
        And I should see an error message indicating invalid price
