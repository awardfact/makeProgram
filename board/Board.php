<?php

namespace Component\Sangjin;

use App;

class Board
{
    private $db;
    
    public function __construct(){

        //$db 변수에 DB모듈을 로드합니다.
        $this->db = App::load('DB');
        /*
         * App::load('DB');는 \App::load('DB");처럼 역슬러시를 이용해서 작성이 가능하지만 ,
         * Class 선언부 위에 use App; 라인을 이용해서 App을 사용할 수 있습니다.
         * 이렇게 선언하는 이유는 코드가 길어질수록 App을 사용하는 곳 역시 많이 질 수 있기 때문에 매번 \App을 사용하거나
         * 뒤에 소스코드를 수정하는 사람이 \를 사용하지않고 App을 사용했을 때 오류를 방지해주기 위한 권장사항입니다.
         *
         * */
    }

    // db에서 데이터를 받아서 데이터를 리턴해준다
    public function getBoardList($postValue) {
        
        $start= $postValue['page'] * $postValue['selectedNumber'];
        
        $sql = "SELECT * FROM wm_test order by sno desc limit ".$start.", ".$postValue['selectedNumber']." ";
        return $this->db->query_fetch($sql);
    }
    
    // 게시글 숫자를 얻어내는 함수 
    // $b에는 게시글 수가 들어간다 
    public function getBoardCount(){
        
        $sql = "SELECT COUNT(*) FROM wm_test";   
        $a =  $this->db->fetch($sql);
        $b = $a[COUNT.'(*)'];
        return $b;

    }

    /*
     * 매개변수를 입력값으로 받아서 db에 입력 데이터를 추가해준다 
     */
    public function makeList($postValue){
        $title = $postValue['title'];
        $content = $postValue['content'];
        $writer = $postValue['writer'];
        $image = $postValue['image'];
        
        //예제코드 2 방법
        $sql = "INSERT INTO wm_test SET title = '".$title."', content = '".$content."' , writer = '".$writer."' ,imagePath = '".$image."'";
        $this ->db -> bind_param_push($arrBind, $title, 'title');
        $this ->db -> bind_param_push($arrBind, $content, 'content');
        $this ->db -> bind_param_push($arrBind, $writer, 'writer');
        $this -> db -> bind_param_push($arrBind, $image, 'imagePath');
        $this->db->bind_query($sql, $arrBind);
        
        /*예제코드 1 방법
        $arrBind = $this->db->get_binding($defaultSetting, $postValue, 'insert'); 
        $this->db->set_insert_db('wm_test', $arrBind['param'], $arrBind['bind'],'y');
        */
    }
    
    /*
     * 입력값과 sno값을 받아서 db에 있는 sno가 일치하는 컬럼값을 수정해준다 
     */
    public function updateList($postValue){
        
        
        //예제코드 2 방법
        $strSQL = "UPDATE wm_test SET title = '".$postValue['title']."' , content = '".$postValue['content']."', writer = 
        '".$postValue['writer']."' , imagePath = '".$postValue['image']."' WHERE  sno = '".$postValue['sno']."'";
        $this ->db->bind_param_push($arrBind,$postValue['sno'], 'sno');
        $this->db->bind_query($strSQL,$arrBind); 
        
        
        

    }
    
    /*
     *  매개변수로 sno값을 받은 다음에 db에 sno값과 일치하는 컬럼값을 삭제한다 
     */
    
    public function deleteList($postValue){

        $writer = $postValue['writer'];
        
        gd_debug($postValue);
        //예제코드 2 방법
        foreach($postValue as $value){

            $sql = "SELECT * FROM wm_test where sno = '".$value."'  AND writer = '".$writer."' ";
            if($this->db->query_fetch($sql)){
                $query = "DELETE FROM wm_test WHERE sno = '".$value."' ";
                $this ->db->bind_param_push($arrBind,$value, 'sno');
                $this->db->bind_query($query,$arrBind);
                
                
                
                $query2 = "DELETE FROM wm_sangjin WHERE board_number ='".$value."'";
                $this -> db -> bind_param_push($arrBind, $value, 'board_number');
                $this-> db-> bind_query($query2,$arrBind);
                
            }else if($value != '' && $value != 'delete' && $value != $writer){
                echo "<script> alert('자신이 작성한 게시글만 삭제할 수 있습니다.');</script>";
                
            }
        }        
    }
    
    // 입력한 댓글을 db에 넣는다 
    public function insertComment($postValue){
        
        $sql = "INSERT INTO wm_sangjin SET board_number = '".$postValue['sno']."' , 
            comment = '".$postValue['comment']."' , writer = '".$postValue['writer']."'";
        $this-> db -> bind_param_push($arrBind, $postValue['sno'], 'board_number');
        $this-> db -> bind_param_push($arrBind, $postValue['commnet'], 'commnet');
        $this-> db -> bind_param_push($arrBind, $postValue['writer'], 'writer');
        $this->db->bind_query($sql, $arrBind);        
        
        
        $sql = "INSERT INTO wm_test SET title = '".$title."', content = '".$content."' , writer = '".$writer."' ,imagePath = '".$image."'";
    }
    
    
    // 매개변수로 보낸 게시글의 sno값과 댓글의 board_number가 일치하는 댓글을 리턴해준다 
    public function selectComment($sno){
        
        $sql = "SELECT * FROM wm_sangjin  where board_number = '".$sno."' order by sno desc";
        return $this->db->query_fetch($sql);
        
        
    }
    
    
    /*현재 게시판에 보이는 게시글들의 댓글 숫자를 얻어내는 함수 
    * 현재 게시판에 보이는 게시글의 내용을 넘기고 게시글의 sno와 board_number와 일치하는 댓글의 개수가 몇 개인지
    * 알아낸 다음에 배열에 넣고 배열을 리턴시켜준다 
    */
    public function getCommentList($postValue){
        $commentNumber;
        $i = 1;
        for($j =0; $j < count($postValue); $j++){
            $sql = "SELECT * FROM wm_sangjin where board_number = '".$postValue[$j]['sno']."'";
            $result = $this->db->query_fetch($sql);
            $commentNumber[$j] =count($result);
        }

        return $commentNumber;
        
    }
    
    
    
    /*
     *  댓글을 수정하는 함수 
     *  보내온 댓글 sno번호와 동일한 댓글의 내용을 매개변수로 보낸 입력한 댓글내용으로 교체해준다  
     */
    public function updateComment($postValue){
        
        $sql = "UPDATE wm_sangjin SET comment = '".$postValue['comment']."'WHERE 
        board_number = '".$postValue['boardSno']."' AND sno = '".$postValue['sno']."' ";
        $this->db->bind_param_push($arrBind, $postValue['comment'], 'comment');
        $this->db->bind_query($sql,$arrBind);
        
    }
    /*
     * 댓글을 삭제하는 함수 
     * 보내온 댓글의 sno번호와 동일한 댓글을 삭제한다 
     */
    public function deleteComment($postValue){
        
        $writer = $postValue['writer'];
        $sql = "SELECT * from wm_sangjin WHERE sno = '".$postValue['sno']."' AND
         board_number = '".$postValue['boardSno']."' AND  writer = '".$writer."' ";
        if($this->db->query_fetch($sql)){
            
            
            $query = "DELETE FROM wm_sangjin WHERE board_number = '".$postValue['boardSno']."' 
            AND sno = '".$postValue['sno']."' AND writer = '".$writer."' ";
            $this-> db -> bind_param_push($arrBind, $postValue['boardSno'], 'board_number');
            $this -> db -> bind_param_push($arrBind, $postValue['sno'], 'sno');
            $this -> db -> bind_param_push($arrBind, $writer, 'writer');
            $this -> db -> bind_query($query,$arrBind);
            return 1;
        }else{
           return 0;
            
         }
        
            
        

        
    }
    
    public function idExistCheck($postValue){
        
        
        
        $sql = "SELECT * FROM wm_sangjin_member  where  id = '".$postValue['inputId']."'";
        $check = $this->db->query_fetch($sql);
       
        
        if($check){
            return 0;
            
        }else{
            return 1;
        }
        
        
    }
    
    public function insertMember($postValue){
        
        $sql = "INSERT INTO wm_sangjin_member SET id = '".$postValue['inputId']."' , password = '".$postValue['inputPassword']."' ";
        $this-> db -> bind_param_push($arrBind, $postValue['inputId'], 'id');
        $this-> db -> bind_param_push($arrBind, $postValue['inputPassword'], 'password');

        $this->db->bind_query($sql, $arrBind);
        
        
    }
    
    public function loginMember($postValue){
        $sql = "SELECT * FROM wm_sangjin_member where  id = '".$postValue['inputId']."' AND password = '".$postValue['inputPassword']."'";
        $check = $this->db->query_fetch($sql);
        
        if($check){
            return 1;
            
        }else{
            return 0;
        }
        
        
        
    }
    
    
}