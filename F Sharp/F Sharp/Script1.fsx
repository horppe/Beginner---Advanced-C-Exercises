
let x = "Hello World"
let ints =[|1; 2; 3; 4; 5; 6|]
let summedValue = ints |> Array.sum
let multiplied = ints |> Array.map (fun i -> i * 2)
