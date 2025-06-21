<?php
    require_once __DIR__ . '/../src/autoloader.php';
    use src\Entities\Cart;
    use src\Services\InputParser;
    use src\Services\OutputFormatter;

$inputs=[
        1=>[
            '2 book at 12.49',
            '1 music CD at 14.99',
            '1 chocolate bar at 0.85'
        ],
        2=>[
            '1 imported box of chocolates at 10.00',
            '1 imported bottle of perfume at 47.50'
        ],
        3=>[
            '1 imported bottle of perfume at 27.99',
            '1 bottle of perfume at 18.99',
            '1 packet of headache pills at 9.75',
            '3 box of imported chocolates at 11.25'
        ],
        4=>[
            '2 bottle of perfume imported at 27.99',
            '1 bottle of imported perfume at 18.99',
            '4 packet of imported headache pills at 9.75',
            '3 box of chocolates at 11.25'
        ]
    ];



    $inputParser=new InputParser();


    $carts=[];
    $cartsNumber=1;
    foreach ($inputs as $input) {

        echo "Input ".$cartsNumber.":<br //>\n";
        $carts[$cartsNumber] = new Cart();

        foreach($inputs[$cartsNumber] as $input){
            echo $input."<br //>\n";
            $carts[$cartsNumber]->addItem($inputParser->parse($input));
        }

        echo "<br //>\n";
        $cartsNumber++;
    }

    echo "OUTPUT<br //>\n";

    for($i=1;$i<$cartsNumber;$i++){
        echo "<br //>\n";
        echo "Output ".$i.":<br //>\n";
        OutputFormatter::printCart($carts[$i]);
    }
