<?php
spl_autoload_register(function ($class): void {
    // Remove leading 'src\' if present
    if (strpos($class, 'src\\') === 0) {
        $class = substr($class, 4);
    }
    $classPath = str_replace('\\', DIRECTORY_SEPARATOR, $class);
    $baseDir = __DIR__ . '/';
    $file = $baseDir . $classPath . '.php';
    if (file_exists($file)) {
        require_once $file;
    }
});
