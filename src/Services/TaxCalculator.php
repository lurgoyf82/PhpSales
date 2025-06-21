<?php
namespace src\Services;

use src\Entities\Item;

class TaxCalculator
{
    static function calculateTaxes(Item $item): float
    {
        $taxes = ($item->price / 100) * $item->taxPercentage;

        //arrotondo le tasse al prossimo 0.05
        if ($taxes > 0) {
            //il buon copilot mi ha suggerito questo
            $taxes = ceil($taxes * 20) / 20;


            /* io avrei fatto cosi, lo lascio qui per completezza
             *
             *   $taxes = (ceil($taxes * 100))/100;
             *
             *   $interi = (int)floor($taxes);
             *   $decimali= ceil(($taxes - $interi)*100);
             *
             *   var_dump($interi,$decimali);
             *
             *   while ($decimali%5!==0) {
             *       $decimali++;
             *   }
             *
             *   $taxes=$interi+($decimali/100);
             *
             */
        }

        return $taxes;
    }
}