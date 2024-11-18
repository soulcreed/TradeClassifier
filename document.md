Question 2: A new category was created called PEP (politically exposed person). Also, a new bool property
IsPoliticallyExposed was created in the ITrade interface. A trade shall be categorized as PEP if
IsPoliticallyExposed is true. Describe in at most 1 paragraph what you must do in your design to account for this
new category.

R: To implement the new "PEP" (Politically Exposed Person) category, we need to add a new strategy class that implements the `ITradeCategoryStrategy` interface. 
This strategy should check the `IsPoliticallyExposed` property of the `ITrade` interface, and if its value is `true`, the trade should be categorized as "PEP". 
