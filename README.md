# NewsForYou
1.Open IIS then right click on Sites and click on Add website
![Screenshot (20)](https://github.com/Pratiksham178/Training/assets/138674356/ab00d496-2eef-41de-ad32-3bf9da6ac3fa)



2.After clicking that the below window will open 
add the path of web-config file in physical path
give the site name and host name as you wish (for example:NewsSite)
![Screenshot (21)](https://github.com/Pratiksham178/Training/assets/138674356/3a37c989-4bbc-4162-9a22-ca85624d2e35)


3.Now open Cdrive>>ProgramFiles(✖82)>>System32>>drivers>>etc>>Host file and add your domain name as given below. As you cannot directly change the file you need to copy it to somewhere else and then change it then replace the host file in Cdrive.
![Screenshot (22)](https://github.com/Pratiksham178/Training/assets/138674356/cd4205ec-5357-4a2d-ab05-8fde97ff9c3e)

4.You need to set the LoginPage as the default page so for that click on the newssite on the left panel and then open the default document
![Screenshot (25)](https://github.com/Pratiksham178/Training/assets/138674356/36de731d-ca61-48de-8105-cc0e988b3710)
after opening that right click on the screen and click on Add
![Screenshot (27)](https://github.com/Pratiksham178/Training/assets/138674356/93ded7d4-c1b6-4093-8e1f-7b13588b1c2c)
After that write LoginPage.aspx in the name section
![Screenshot (28)](https://github.com/Pratiksham178/Training/assets/138674356/ca95fa21-4c9b-4868-8557-0444458dac53)
You will see LoginPage is added to the list
![Screenshot (29)](https://github.com/Pratiksham178/Training/assets/138674356/2733f0ef-5306-47d0-9fff-e184656dd2cf)




5.Now you can just type hostname/ to open the site
here the host name was Newssite so it would be newssite/
![Screenshot (24)](https://github.com/Pratiksham178/Training/assets/138674356/c8828f8e-9779-42be-8131-d80b7134cb0c)

On clicking on Initialize, it will delete all the table's data and then insert details into 4 tables that is the user table with login details(Default email:liti624@gmail.com, password:user123), the agency table, the agency feed table with the RSS links and the category table.The news table will get automatically filled after opening the NewsPage and it will keep on updating itself when news gets added to the RSS links.



