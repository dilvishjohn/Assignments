Systemates Inc. currently issues two types of Purchase Orders (PO): Office Supplies PO and Computer Equipment PO. These Purchase Orders can be issued to either a retail supplier or a wholesale supplier. 

Assume that the purchase order object places an order to the supplier through a method called IssueOrder() that requires a Supplier, ProductId and Quantity desired as input parameters. The ProductId is the Id of the Office Supplies product or a Computer Equipment product or any other Purchase Order type product.

Assume that the supplier that receives this Order processes it through a method called ProcessOrder(). This method expects the ProductId and Quantity information to process the order.

The output must be the following:

    1. A message from the IssueOrder method that says :
“Issued Purchase Order for X to supplier Y”

Where X is the Purchase Order Type and Y is the Supplier type


    2. A message from the ProcessOrder() method that says : 
“Message from Supplier X: Received order for Y quantity of Product Z. The order will be processed in N days”

Where X is the Supplier type, Y is the Quantity desired, Z is the ProductId and N is the number of days. 

Architect and write a program that will implement this functionality. The program must be extensible enough to accommodate many additional Purchase Order types as well as many additional Suppliers without the need for rewriting methods. If you desire, you can repeat the output messages for different combinations of Purchase Orders and Suppliers.

The solution should handle any errors that may occur and be easy for other developers to pick up and extend at a later date. You will need to create a new project in Visual Studio, you may create a console, web or desktop application, whichever you feel it will be easiest to solve the problem with. 
