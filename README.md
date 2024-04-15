Windows Forms Application that generates a simple invoice as a pdf.
It only uses input data received through the UI and updates the invoice number in a json file.

***DESIGN PATTERNS***

**SINGLETON**
Implemented in the InvoiceGenerator class. The constructor is private, so no other instances of the class can be created from outside.
The GetInstance() method ensures that there is only one instance of the class and returns that instance.

**FACTORY METHOD**
It is implemented in the creation logic of the InvoiceGenerator class. The TaxInvoiceFactory methods implement the IInvoiceFactory interface, allowing instances of the Invoice class to be created to make specific types of invoices.

**OBSERVER/PUBLISHER-SUBSCRIBER**
I am combining elements from Observer and Publisher-Subscriber patterns. The Observer pattern is used to inform other sections of the application about the occurrence of invoice generation events, while Publisher-Subscriber establishes the connection between the object producing the event (publisher) and the objects responding to events (subscribers).
It centers around the idea of triggering events and enabling other parts of the application to respond accordingly.
