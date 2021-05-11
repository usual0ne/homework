function task1(arr)
{
    let initArrSum = 0;
    let changedArrSum = 0;
    for(let i = 0; i < arr.length; i++)
    {
        arr[i] = Number(arr[i]);
        initArrSum += arr[i];

        if(arr[i] % 2 == 0)
        {
            arr[i] += i;
        }
        else if(arr[i] % 2 != 0)
        {
            arr[i] -= i;
        }

        changedArrSum += arr[i];
    }

    console.log(arr);
    console.log(initArrSum);
    console.log(changedArrSum);
}

console.log('task1:');
task1(['-5', '11' , '3', '0', '2']);



function task2(arr1, arr2)
{
    for(let e1 of arr1)
    {
        for(let e2 of arr2)
        {
            if(e1 === e2)
            {
                console.log(e1);
            }
        }
    }
}

console.log('task2:');
task2(['R', 'u', 's', 's', 'i', 'a'], ['R', 'u', 't']);


function task3(arr, shiftsLeft)
{
    let tempArr = [];
    for(let i = 0; i < arr.length; i++)
    {
        tempArr[i] = arr[i];
    }

    for(let i = 0; i < arr.length; i++)
    {
        let swappingIndex = (i + shiftsLeft % arr.length) % arr.length;
        arr[i] = tempArr[swappingIndex];

    }
    console.log(arr.join(' '));
}

console.log('task3:');
task3([2, 4, 15, 31], 5);


function task4(matrix)
{
    let rowsSums = [];
    let columnsSums = [];
    for(let i = 0; i < matrix.length; i++)
    {
        rowsSums[i] = 0;
        columnsSums[i] = 0;
        for(let j = 0; j < matrix.length; j++)
        {
            rowsSums[i] += matrix[i][j];
            columnsSums[i] += matrix[j][i];
        }
    }

    let isWonderful = true;
    for(let i = 0 ; i < rowsSums.length; i++)
    {
        for(let j = 0; j < columnsSums.length; j++)
        {
            if(rowsSums[i] !== columnsSums[j])
            {
                isWonderful = false;
            }
        }
    }

    console.log(isWonderful);   
}

console.log('task4:');
task4([[1, 0, 0],
       [0, 0, 1],
       [0, 1, 0]]);