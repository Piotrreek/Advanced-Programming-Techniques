Feature: Create a New Product
        As a user of the system
        I want to create a new product
        So that I can add it to the product catalog

    @createProduct
    Scenario: Create Product
        When I create the product with name 'SampleProduct', quantity '10', price '99.99', description 'A sample product.'
        Then product with name 'SampleProduct', quantity '10', price '99.99', description 'A sample product.' should be created