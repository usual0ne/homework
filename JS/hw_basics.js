//age
function task1(age)
{
    if(age >= 0 && age <= 2)
    {
        console.log('младенец');
    }
    else if(age >= 3 & age <= 13)
    {
        console.log('ребенок');
    }
    else if(age >= 14 & age <= 19)
    {
        console.log('подросток');
    }
    else if(age >= 19 & age <= 65)
    {
        console.log('взрослый');
    }
    else if(age >= 66)
    {
        console.log('пожилой');
    }
}

//rounding
function task2(number, precision)
{
    if(precision > 15)
    {
        console.log(parseFloat(number.toFixed(15)));
    }
    else if(precision >= 0 && precision <= 15)
    {
        console.log(parseFloat(number.toFixed(precision)));
    }
}

//divisor
function task3(num)
{
    if(num % 10 == 0)
    {
        console.log(`Число делится на 10`);
    }
    else if(num % 7 == 0)
    {
        console.log(`Число делится на 7`);
    }
    else if(num % 6 == 0)
    {
        console.log(`Число делится на 6`);
    }
    else if(num % 3 == 0)
    {
        console.log(`Число делится на 3`);
    }
    else if(num % 2 == 0)
    {
        console.log(`Число делится на 2`);
    }
    else
    {
        console.log('Не делится')
    }
}

//vacation
function task4(peopleCount, groupType, day)
{
    if(groupType == "Students")
    {
        if(day == "Friday")
        {
            if(peopleCount >= 30)
            {
                console.log(`Total price: ${(peopleCount * 8.45 * 0.85).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 8.45).toFixed(2)}`);
            }
        }
        else if(day == "Saturday")
        {
            if(peopleCount >= 30)
            {
                console.log(`Total price: ${(peopleCount * 9.80 * 0.85).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 9.80).toFixed(2)}`);
            }
        }
        else if(day == "Sunday")
        {
            if(peopleCount >= 30)
            {
                console.log(`Total price: ${(peopleCount * 10.46 * 0.85).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 10.46).toFixed(2)}`);
            }
        }
    }


    else if(groupType == "Corporate")
    {
        if(day == "Friday")
        {
            if(peopleCount >= 100)
            {
                console.log(`Total price: ${((peopleCount - 10) * 10.90).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 10.90).toFixed(2)}`);
            }
        }
        else if(day == "Saturday")
        {
            if(peopleCount >= 100)
            {
                console.log(`Total price: ${((peopleCount - 10) * 15.60).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 15.60).toFixed(2)}`);
            }
        }
        else if(day == "Sunday")
        {
            if(peopleCount >= 100)
            {
                console.log(`Total price: ${((peopleCount - 10) * 16).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 16).toFixed(2)}`);
            }
        }
    }


    else if(groupType == "Regular")
    {
        if(day == "Friday")
        {
            if(peopleCount >= 10 && peopleCount <= 20)
            {
                console.log(`Total price: ${(peopleCount * 15 * 0.95).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 15).toFixed(2)}`);
            }
        }
        else if(day == "Saturday")
        {
            if(peopleCount >= 10 && peopleCount <= 20)
            {
                console.log(`Total price: ${(peopleCount * 20 * 0.95).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 20).toFixed(2)}`);
            }
        }
        else if(day == "Sunday")
        {
            if(peopleCount >= 10 && peopleCount <= 20)
            {
                console.log(`Total price: ${(peopleCount * 22.50 * 0.95).toFixed(2)}`);
            }
            else
            {
                console.log(`Total price: ${(peopleCount * 22.50).toFixed(2)}`);
            }
        }
    }
}

//leap year
function task5(year)
{
    if((year % 4 == 0 || year % 400 == 0) && year % 100 != 0)
    {
        console.log("yes");
    }
    else
    {
        console.log("no");
    }
}