Feature: orderAProduct

In this feature we test for the checkout process + check the history of orders

@get
Scenario: Order 2 Cup<T> White Mug
	Given User logged in with email add demouser@microsoft.com and password Pass@word1
	And select BRAND = Other
	When User add product <ItemName> in the basket
	Then directed to the basket
	Given User change the quantity to <quantity>
	And User click on the button UPDATE
	When User click on the button CHECKOUT
	Then directed to the review page
	And item is <ItemNameInBasket> on the review page and quantity is <quantity>
	When User click on the button PAYNOW
	Then directed to the page Thanks for your order
	Given user hover on the email address on the top and click on my orders
	When click on the button Detail for the latest item
	Then item on order details is <ItemNameInBasket> and quantity is <quantity>
	Examples: 
	| ItemName                  | ItemNameInBasket          | quantity |
	| CUP<T> WHITE MUG          | Cup<T> White Mug          | 2        |
	| KUDU PURPLE SWEATSHIRT    | Kudu Purple Sweatshirt    | 4        | 


Scenario: Order a product with an invalid quantity
	Given User logged in with email add demouser@microsoft.com and password Pass@word1
	And select BRAND = Other
	When User add product <ItemName> in the basket
	Then directed to the basket
	Given User change the quantity to <quantity>
	And User click on the button UPDATE
	Then an alert is displayed - Value must be greater than or equal to 0
	And directed to the basket
	Examples: 
	| ItemName                  | ItemNameInBasket          | quantity |
	| CUP<T> WHITE MUG          | Cup<T> White Mug          | -1       |

Scenario: Order different type of products
	Given User logged in with email add demouser@microsoft.com and password Pass@word1
	And select BRAND = <BrandType>
	And Add <numOfProducts> products in the basket for BRAND = <BrandType>
	When User click on the button CHECKOUT
	Then directed to the review page
	When User click on the button PAYNOW
	Then directed to the page Thanks for your order
	Given user hover on the email address on the top and click on my orders
	When click on the button Detail for the latest item
	Then check number of prodcuts is <numOfProducts>

	Examples: 
	| BrandType  | numOfProducts |
	| Other      | 5             |
	| .NET       | 2             |

	