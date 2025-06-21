<?php
declare(strict_types=1);

namespace src\Services;

use src\Entities\Item;
use src\Entities\Taxes;
use src\Services\TaxCalculator;

class InputParser
{
    private ?string $text;
    private ?Item $item;
    private const ITEMTYPE = [
        'book' => 'book',
        'music CD' => 'other',
        'chocolate bar' => 'food',
        'box of chocolates' => 'food',
        'bottle of perfume' => 'other',
        'packet of headache pills' => 'medical_products'
    ];

    public function __construct(?string $text = null)
    {
        // $text puo essere null in fase di creazione dell'oggetto, non ritorna errore
        $this->text = $text;
        $this->item = null;
    }

    public function setText(string $text): void
    {
        $this->text = $text;
        $this->item = null;
    }

    public function parse(?string $text = null): Item
    {
        if ($text !== null) {
            $this->setText($text);
        }

        // Se l'item è già stato creato, lo ritorno
        if ($this->item !== null) {
            return $this->item;
        }

        // $text a questo punto deve per forza essere valorizzato
        if ($this->text === null) {
            throw new \InvalidArgumentException("Input text cannot be null");
        }

        $item = new Item();

        //example: "3 box of imported chocolates at 11.25"
        $text = trim($this->text);

        // Quantità
        $quantityEndCharPos = strpos($text, ' ');
        $item->quantity = (int)substr($text, 0, $quantityEndCharPos);

        // Prezzo
        $atFirstCharPos = strripos($text, 'at');
        $item->price = (float)trim(substr($text, $atFirstCharPos + 2));

        $text= trim(substr($text, $quantityEndCharPos,$atFirstCharPos-1));


        $importedFirstCharPos=strpos($text, 'imported');

        // Check imported
        if($importedFirstCharPos === false) {
            $item->imported=false;
            $item->taxPercentage=0;

            // Nome
            $item->name = $text;
        } else {
            $item->imported=true;
            $item->taxPercentage=5; // 5% di tassa per gli importati
            $text= trim(trim(substr($text, 0, $importedFirstCharPos)).' '.trim(substr($text, $importedFirstCharPos+8)));


            // Nome
            $item->name = 'imported '.$text;
        }

        // Tipo di item
        $item->itemType = self::ITEMTYPE[$text] ?? 'other';
        $item->taxPercentage+= Taxes::{$item->itemType};

        // Calcolo le tasse
        $item->taxes = $item->quantity * (TaxCalculator::calculateTaxes($item));
        $item->taxedPrice = ($item->quantity * $item->price) + $item->taxes;

        $this->item=$item;

        return $this->item;
    }
}












