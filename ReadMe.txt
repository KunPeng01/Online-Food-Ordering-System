The main controllers utilized in the application are the CustomerController, AdminController, OrderController, and RoleController

1. CustomerController
Purpose: This controller manages customer-related functionality, including customer creation, updating, viewing, and managing their account details.
Actions:
- Create: Allows customers to create an account. If the model is valid, the customer is added to the database, and a "Thanks" page is displayed.
- Index: Displays all products from the database.
- Create (GET): Displays the customer registration form.
- Thanks: Displays a confirmation page after a customer has been created.
- Login: Displays the login page 
- CustomerExists: A helper method that checks if a customer with a given UserId exists in the database.

2. AdminController
Purpose: This controller handles administrative tasks related to managing products in the online store.
Actions:
- Index: Displays all products in the system.
- CreateProduct (GET and POST): Displays a form for creating new products and saves them to the database upon form submission.
- EditProduct (GET and POST): Allows the administrator to edit the details of an existing product. The GET method displays the product for editing, while the POST method saves the changes.
- DeleteProduct: Deletes a product from the database and redirects back to the product list.

3. OrderController
Purpose: This controller manages shopping cart and order-related functionality.
Actions:
- AddToCart (POST): Adds a product to the user's shopping cart. If the product is already in the cart, its quantity is updated. If not, a new order item is added. The cart is stored in the session.
- Index: Displays the items
- OrderConfirmation: Displays an order confirmation page after an order is placed.
- ShowCart: Displays the current items in the cart.
- Checkout (GET and POST): Displays the checkout form and handles order submission. If the form is valid, it redirects to the order confirmation page.

4. RoleController
Purpose: This controller manages roles and role assignment
Actions:
- Index: Displays the roles
- Errors: Handles errors related to role creation and deletion
- Create (GET and POST): Displays role creation form, and handles role creation
- Delete (POST): Handles role deletion
- Update (GET and POST): Displays role update form, and adding roles to users 

The role pages for creating new roles and assigning roles to users is not accessible through the UI.
The user must access the role pages through 