Feature: Create a new product with too long name
        As a user of the system
        I want to be prevented from creating a product with too long name
        So that only valid product names with length less than 21 are only allowed 

    @invalidNameLength
    Scenario: Failing to create a product with a name that is too long
        When I try to create the product with too short name 'ThisIsAnExtremelyLongProductNameThatIsInvalid', quantity '10', price '99.99', description 'A sample product.'
        Then the system should not create product
        And I should see an error message indicating the name length is too long