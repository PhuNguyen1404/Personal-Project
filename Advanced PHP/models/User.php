<?php

class User
{
    public $conn;
    public $errors = [];
    public $user = [];
    public $users = [];
    public $username;
    public $user_email;
    private $hash;
    public $user_role;

    public function __construct($conn)
    {
        $this->conn = $conn;
    }

    /*
    public function initAdmin()
    {
        $sql = "SELECT * from user";
        $stmt = $this->conn->prepare($sql);
        $stmt->execute();
        $result = $stmt->get_result();
        if ($result->num_rows < 1) {
            $this->username = "admin";
            $this->hash = password_hash("itec2023", PASSWORD_DEFAULT);
            $this->user_email = "admin@gmail.com";
            $this->user_role = "1";
            $this->createNewUser();
        }
    }
    */

    public function userExists($username) {
        $sql = "SELECT * FROM user WHERE user_name = ?";
        $stmt = $this->conn->prepare($sql);
        $stmt->bind_param("s", $username);
        $stmt->execute();
        $result = $stmt->get_result();
        $this->user = $result->fetch_assoc(); // grab assoc array if user exists else empty
        if(!empty($this->user)) {
            return true; // user found
        }  else {
            return false; // user not found
        }
    }

    public function createNewUser($username, $pw, $email)
    {
        // hash the password
        $hash = password_hash($pw, PASSWORD_DEFAULT);
        // create sql statement with ??? placeholders
        $user_role = 2;
        $sql = "INSERT INTO user(user_name, user_password, user_role) VALUES(?,?,?)";
        // create stmt and call prepate method (on $this->conn)
        $stmt = $this->conn->prepare($sql);
        // bind param
        $stmt->bind_param("sss", $username, $hash, $user_role);
        // execute  
        $stmt->execute();
        // if affected_rows === 1 success , else error
        if ($stmt->affected_rows === 1) {
            return true;
        } else {
            return $stmt;
        }
    }

}