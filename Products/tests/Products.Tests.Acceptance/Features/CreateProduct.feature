@CreateProduct
Feature: Create a New Product
        As a user of the system
        I want to create a new product
        So that I can add it to the product catalog

    @CreateProduct_1
    Scenario: Create product with valid data
        When I create the product with name 'SampleProduct', quantity '10', price '99.99', description 'A sample product.'
        Then product with name 'SampleProduct', quantity '10', price '99.99', description 'A sample product.' should be created
        
    @CreateProduct_2
    Scenario: Create product with too long name
        When I create the product with name 'ThisIsAnExtremelyLongProductNameThatIsInvalid', quantity '10', price '99.99', description 'A sample product.'
        Then the system should not create product
        And I should see an error message indicating the name length is too long
        
    @CreateProduct_3
    Scenario: Create product with too short name
        When I create the product with name 'AA', quantity '10', price '99.99', description 'A sample product.'
        Then the system should not create product
        And I should see an error message indicating the name length is too short
        
    @CreateProduct_4
    Scenario: Create product with negative quantity
        When I create the product with name 'SampleProduct', quantity '-1', price '99.99', description 'A sample product.'
        Then the system should not create product
        And I should see an error message indicating the quantity is invalid
        
    @CreateProduct_5
    Scenario: Create product with negative price
        When I create the product with name 'SampleProduct', quantity '5', price '-99.99', description 'A sample product.'
        Then the system should not create product
        And I should see an error message indicating invalid price