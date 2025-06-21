<?php
namespace src\Services;

use src\Entities\Item;
use src\Entities\Cart;

class OutputFormatter
{

    private static function formatItem(Item $item): string
    {
        return $item->quantity.' '.$item->name.': '.
            number_format($item->taxedPrice, 2, '.', '');
    }

    public static function printCart(Cart $cart): void
    {
        foreach ($cart->getItems() as $item) {
            $formattedOutput = self::formatItem($item);
            echo $formattedOutput . "<br />\n";
        }

        echo "Sales Taxes: " . number_format($cart->getTax(), 2, '.', ''). "<br />\n";
        echo "Total: " . number_format($cart->getTotal(), 2, '.', '') . "<br />\n";
    }
}
