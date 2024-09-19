<?php

class DB {
    protected $conn;

    public function __construct($host, $user, $pw, $db) {
        $this->conn = new mysqli($host, $user, $pw, $db);
    
    }

    public function getConnection() {
        return $this->conn;
    }
}

?>