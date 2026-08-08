# Clinic Patient Visit Monitoring System

A simple ASP.NET Core MVC web application for a clinic front desk to register patient visits, track their status through the day (waiting, in consultation, completed), and search/manage visit records. Includes basic username/password authentication for staff accounts.

## Creating an Account

1. Go to the **Register** page from the top navigation.
2. Fill in your first name, last name, email, username, and password.
3. Password must be at least 6 characters. Confirm it in the second password field.
4. Click **Register**. You will then be able to log in.

## Logging In

1. Go to the **Login** page.
2. Enter your username and password.
3. Optionally check **Remember me** to stay signed in.
4. Click **Login**. You will land on the home page, and the navigation bar will now show your name and a Logout button.

## Adding (Registering) a Patient Visit

1. Click **Register Visit** in the navigation bar, or **Register Patient Visit** from the Monitoring List page.
2. Fill in the patient details: first name, last name, age, sex, contact number, address.
3. Fill in the visit details: physician, visit type (Walk-in, Follow-up, Emergency, Referral), and arrival date/time.
4. Enter the chief complaint (reason for the visit) and any additional notes if needed.
5. Click **Register Visit**. The patient is added to the Monitoring List with status **Waiting**.

## Viewing All Patients

- Click **Monitoring List** in the navigation bar.
- You will see a summary of Total, Waiting, In Consultation, and Completed visits at the top, followed by a table of all visits.

## Searching for a Patient

1. On the Monitoring List page, use the search box.
2. You can search by visit number, patient name, physician, or status.
3. Click **Search**. Click **Clear** to reset the search and show all visits.

## Updating a Patient Visit

1. On the Monitoring List page, find the patient's row.
2. Click the edit (pencil) icon.
3. Update any fields as needed.
4. Click **Save Changes**.

## Viewing Visit Details

- Click the eye icon on a patient's row to see the full visit record, including status, complaint, and notes.

## Starting a Consultation

- For a patient with status **Waiting**, click the play (Start) icon on their row.
- Their status changes to **In Consultation**.

## Completing a Visit

1. Click the checkmark (Complete) icon on a patient's row.
2. Confirm on the next screen by clicking **Confirm Completion**.
3. The status changes to **Completed** and the consultation end time is recorded.

## Logging Out

- Click **Logout** in the navigation bar.
