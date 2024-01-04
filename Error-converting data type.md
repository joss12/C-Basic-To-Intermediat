

Error converting data type varchar to numeric

Hello!

A couple of common issues have popped up for some of my students from different parts of the world.


First:
In the next lecture when we try to insert a decimal value to our table in the SQL Database, some people will receive an error like the title of this lecture "Error converting data type varchar to numeric".

This is usually because in some areas of the world that use a comma( , ) instead of a period( . ) as a decimal point, and MS SQL Server doesn't understand that format.


The solution to this is to add a formatting conversion that uses InvariantCulture as the provider, and "0.00" as the format with ".ToString("0.00", CultureInfo.InvariantCulture)".

myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)


Second:

In the same piece of code we will attempt to insert a date to our table, some people will receive a different error: "Conversion failed when converting date and/or time from character string".

This is because in some areas the date format is not recognized by MS SQL Server.

The solution to this is also to add a formatting conversion to a standardized format ".ToString("yyyy-MM-dd")"

myComputer.ReleaseDate.ToString("yyyy-MM-dd")




These formatting adjustments should make sure that wherever you are in the world, MS SQL server will accept the values we are going to insert.



I look forward to seeing you in the next lecture!
Dominic