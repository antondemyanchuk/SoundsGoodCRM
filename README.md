Hello!
Welcome to the SoundsGoodCRM project!

SoundsGoodCRM is a program being developed for the network of music workshops 'Sounds Good.' 
Its primary objectives include advertising the workshop's services, simplifying documentation management,
creating new orders, monitoring their progress and payment, storing a database of clients and their musical instruments, 
as well as maintaining a history of customer interactions.

Data Base:
Data Base Scheme:
![Database ER diagram SoundsGoodCRM](https://github.com/antondemyanchuk/SoundsGoodCRM/assets/44449892/2631d79d-ef0e-4d8c-bf0c-82409f52831f)

Homepage: Information about the workshop's services, contacts, promotions, and special offers for clients. 
There is also the option to pay for an order using the order number and the option to submit a request for feedback by filling out a form, 
with full name, contact phone number, and a brief description of the reason for the inquiry or the issue with the musical instrument. 
Additionally, the homepage features a link for customer registration/login to the system.

Registration or login page for the personal account: Contains fields for choosing between registration or logging into the system. 
To register, users need to enter their email, full name, and phone number, create and confirm a password 
(minimum 8 characters, at least one uppercase letter, and one digit). A confirmation email with a one-time password will be sent to the 
provided email address, which users must enter in the corresponding field. There are also plans to add the option for registration through a Google account. 
To log into the account, users need to enter their email and password.

Personal account of three types:
1. Client's account - clients can check or modify their contact information, view the history of inquiries and payments, 
and make payments for ongoing repairs (provided that the repair is already completed and the invoice is issued). 
Integration with payment services (LiqPay, WayForPay, etc.) is planned for payment.
2. Workshop employee's account - allows viewing the entire list of orders with necessary filters (by order status, client contact details, instrument details), 
creating new orders, changing status, list of works, as well as viewing client contact information.
3. Manager's account - in addition to the functionality of the "employee's account," it allows creating and editing employee accounts, 
viewing statistics for selected dates, and the ability to import/export the client database.
