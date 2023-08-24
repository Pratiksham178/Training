# NewsForYou
1.Open IIS then right click on Sites and click on Add website
![Screenshot (20)](https://github.com/Pratiksham178/Training/assets/138674356/ab00d496-2eef-41de-ad32-3bf9da6ac3fa)



2.After clicking that the below window will open 
add the path of web-config file in physical path
give the site name and host name as you wish (for example:NewsSite)
![Screenshot (21)](https://github.com/Pratiksham178/Training/assets/138674356/3a37c989-4bbc-4162-9a22-ca85624d2e35)


3.Now open Cdrive>>ProgramFiles(✖82)>>System32>>drivers>>etc>>Host file and add your domain name as given below. As you cannot directly change the file you need to copy it to somewhere else and then change it then replace the host file in Cdrive.
![Screenshot (22)](https://github.com/Pratiksham178/Training/assets/138674356/cd4205ec-5357-4a2d-ab05-8fde97ff9c3e)

4.Now you can just type hostname/LoginPage to open the site
here the host name was Newssite so it would be newssite/LoginPage
![Screenshot (23)](https://github.com/Pratiksham178/Training/assets/138674356/81c6222d-1f51-49c4-b65c-1879798de905)
On clicking on Initialize, it will delete all the table's data and then insert details into 4 tables that is the user table with login details(Default email:liti624@gmail.com, password:user123), the agency table, the agency feed table with the RSS links and the category table.The news table will get automatically filled after opening the NewsPage and it will keep on updating itself when news gets added to the RSS links.



