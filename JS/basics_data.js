//sum of numbers
function task1(number)
{
    number = number.toString();
    let sum = 0;
    for(let i = 0; i < number.length; i++)
    {
        sum += Number(number[i]);
    }
    console.log(sum);
}
console.log("task1 output:");
task1(543);


//chars to string
function task2(par1, par2, par3)
{
    console.log(`${par1}${par2}${par3}`);
}
console.log("task2 output:");
task2('1', '5', 'p');


//town information
function task3(name, population, area)
{
    console.log(`Town ${name} has population of ${population} and area ${area} square km.`);
}
console.log("task3 output:");
task3('Moscow', '12636312', '2561');

//calculator
function task4(num1, operator, num2)
{
    switch(operator)
    {
        case '+':
            console.log((num1 + num2).toFixed(2));
            break;

        case '-':
            console.log((num1 - num2).toFixed(2));
            break;
        
        case '*':
            console.log((num1 * num2).toFixed(2));
            break;

        case '/':
            console.log((num1 / num2).toFixed(2));
            break;

        case '%':
            console.log((num1 % num2).toFixed(2));
            break;

        default:
            break;
    }
}
console.log("task4 output:");
task4(25.5, '*', 3);

//binary to decimal
function task5(num)
{
    num = num.toString();
    let result = 0;
    for(let i = num.length - 1; i >= 0; i--)
    {
        let power = num.length - 1 - i;
        result += Number(num[i]) * Math.pow(2, power);
    }
    console.log(result);
}
console.log("task5 output:");
task5("11110000");