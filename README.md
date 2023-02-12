# Mse Project

The point of this project, define production lines,work station which is working on production line,temperature and pressure values of work station and alarm page which has their max-min values. If this values out of the range, alarm calls.


## Tech Stack

.Net 6 </br>
EF Core  </br>
MSSQL Server  </br>
Serilog </br>
Automapper </br>
CQRS Design Pattern and MediatR </br>
N-Tier Architecture </br>
Bootstrap

## Screenshots from the project

#### Production Line
We can list,edit and delete in this page. Also we can add new line when we clicked add button.
![ProductionLine](https://user-images.githubusercontent.com/61347219/218306973-eb7e4944-8a94-4443-ad2f-440371e32a40.png)

#### Work Station

We can do crud operations. In add page, our lines come as a dropdownlist.

![AddWorkStation](https://user-images.githubusercontent.com/61347219/218307075-6929e437-a663-4f97-9c63-ccb5557fdf44.png)

#### Responsible Personnel - Work Station

In this struct,I defined it as a many-to-many relationship.. We can define more than a work station to a maintanence personnel.
![personel-workstation](https://user-images.githubusercontent.com/61347219/218307158-e3f3c6ef-49aa-43bf-ad97-38c304ec32a0.png) </br>
![personel-workstationadd](https://user-images.githubusercontent.com/61347219/218307160-f18bd29c-f6dd-440a-ad00-3af63aa3603e.png)

## Alarm

If our values out of the range, the alarm color will be red and the button for sending email becomes active. If our values is valid, the alarm color will be green and button becomes invisible.

![AlarmPage](https://user-images.githubusercontent.com/61347219/218307253-76a18aa2-6e8b-4ebd-aee5-7f801267327f.png)

## Searching Page

We can search by production line name,work station name and start-finish date range in this page.

![searchpage](https://user-images.githubusercontent.com/61347219/218307326-4c83f882-0b32-40c2-896c-4f2fe26dae72.png)

## Console App

We can create random values for work station and send them to post method in my controller. </br>
The format is : </br>
{
WorkStationId : 1,
Temperature : 25.18,
Pressure : 1416.00,
Status: true
}
![console](https://user-images.githubusercontent.com/61347219/218307372-55b28cdf-4f17-442d-b9d2-5b41ce78cfd9.png)

Thank you for reviewing my repo,

Yours sincerely.
