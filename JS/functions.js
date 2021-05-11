function task1(param1, param2)
{    
    return Math.min(param1, param2);
}
console.log("task1:");
console.log(task1(task1(25, 21), 4));


//task2
const arr2 = [58, 100];
function subtract(param1, param2)
{
    return param1 + param2[0] - param2[1];
}
console.log("task2:");
console.log(subtract(42, arr2));


function task3(n)
{
    for(let i = 0; i < n; i++)
    {
        console.log(`${n}`.repeat(n));
    }
}
console.log("task3:");
task3(2);


function task4(num)
{
    if(num < 100 & num >= 0 & num % 10 == 0)
    {
        let decadesCount = num / 10;
        let dotsCount = 10 - decadesCount;
        console.log(num + "%" + " [" + "%".repeat(decadesCount) + ".".repeat(dotsCount) + "]" + "\n");
        console.log("Still loading...");
    }

    else if(num == 100)
    {
        console.log("100% Complete!" + "\n");
        console.log("[" + "%".repeat(10) + "]");
    }
}
console.log("task4:");
task4(100);