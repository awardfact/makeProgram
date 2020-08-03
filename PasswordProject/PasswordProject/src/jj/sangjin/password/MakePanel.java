package jj.sangjin.password;

import java.awt.Cursor;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Toolkit;
import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.StringSelection;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class MakePanel extends JPanel{     //메인메뉴에서 패스워드 만들기를 클릭했을때 나오는 패널
	
	private static int width = 600;
	private static int height = 500;   // 화면크기 
	protected int makeback = 0;    // 메인메뉴로 돌아가기 위한 숫자변수 
	protected int makeScreen = 0;   //  이 패널에서 화면 전환을 위한 숫자변수
	/*int convertPassword = 0;  */
	private int[] tmp = new int[50];    //  input에 입력한 글자의 숫자값을 저장하는 배열
	private int i = 0;   // 반복문 돌기위한 변수
	private char[] element = new char[20];  // tmp의 숫자로 난수를 만들어 그 난수를 받은 것을 아스키 코드로 해서 만든 문자를 저장하는 배열

	private String stringTemp = null;  // element배열을 조합만 문장을 저장하는 변수
	private int passwordLength;   // 비밀번호 길이를 얼마로 할지 사용자가 입력할 변수 

	
	private JButton backButton;  // 좌측상단 뒤로가기 버튼
	private JButton exitButton;  //  우측상단 종료버튼
	private JButton inputFinishButton; // 입력완료버튼
	private JButton koreanBackButton;  // 입력완료버튼 오른쪽 뒤로가기 버튼
	private JButton saveFileButton; // 저장하기 버튼
	private JButton gomainButton; // 메인화면으로 가기 버튼 
	private JButton bigGomainButton;    // 사용 입력하고 메인으로 돌아가기 버튼 
	private JTextField inputField;   // 평문 입력할 텍스트필드
	private JTextField inputNumberField;  // 만들암호 길이 얼마로 할지 입력할 텍스트필드
	private JTextField placeInputField;   // 어디에서 사용할지 입력할 텍스트필드
	private JTextArea password;  //  패스워드 생성된거 표시될 텍스트에리어
 	private Font fieldFont;   // 텍스트필드에 설정할 폰드 
	private Font passwordFont;  // 완성된 패스워드를 보여주


	private BufferedImage order;  // 평문 입력하세요 이미지
	private BufferedImage finishText;  // 패스워드 생성 완료되었습니다 이미지
	private BufferedImage numberOrder;//  패스워드 자리수 입력하세요 이미지
	private BufferedImage passwordBackground;  //만들어진 패스워드 주위 이미지
	private BufferedImage placeOrder; // 장소 입력하세요 이미지
	private ImageIcon backButtonImage = new ImageIcon("back.png");
	private ImageIcon backButtonEnteredImage = new ImageIcon("backEntered.png");
	private ImageIcon exitButtonImage = new ImageIcon("exit.png");
	private ImageIcon exitButtonEnteredImage = new ImageIcon("exitEntered.png");
	private ImageIcon inputFinishButtonImage = new ImageIcon("inputFinish.png");
	private ImageIcon inputFinishButtonEnteredImage = new ImageIcon("inputFinishEntered.png");
	private ImageIcon koreanBackButtonImage = new ImageIcon("koreanBack.png");
	private ImageIcon koreanBackButtonEnteredImage = new ImageIcon("koreanBackEntered.png");
	private ImageIcon gomainButtonImage = new ImageIcon("gomain.png");
	private ImageIcon gomainButtonEnteredImage = new ImageIcon("gomainEntered.png");
	private ImageIcon saveFileButtonImage = new ImageIcon("saveFile.png");
	private ImageIcon saveFileButtonEnteredImage = new ImageIcon("saveFileEntered.png");
	private ImageIcon bigGomainButtonImage = new ImageIcon("bigGomain.png");
	private ImageIcon bigGomainButtonEnteredImage = new ImageIcon("bigGomainEntered.png");   // 버튼에 넣을 이미지아이콘
	
	
	public MakePanel() {
		
		try {
			order = ImageIO.read(new File("MakeOrder.png"));
			finishText = ImageIO.read(new File("finishText.png"));
			numberOrder = ImageIO.read(new File("MakeNumberOrder.png"));
			passwordBackground = ImageIO.read(new File("passwordBackground.png"));  // 만든 버퍼드이미지에서 파일 읽는 코드 
			placeOrder = ImageIO.read(new File("placeOrder.png"));
		}catch(IOException e) {};
		
		this.setLayout(null);   // 배치는 널로한다 
		fieldFont   = new Font("Serif",Font.PLAIN,17);   //텍스트필드 폰트
		passwordFont = new Font("Serif",Font.BOLD,21);  // TextArea폰트
		backButton = new JButton(backButtonImage);  
		exitButton = new JButton(exitButtonImage);
		inputFinishButton = new JButton(inputFinishButtonImage);
		koreanBackButton = new JButton(koreanBackButtonImage);
		gomainButton = new JButton(gomainButtonImage);
		saveFileButton = new JButton(saveFileButtonImage);
		bigGomainButton = new JButton(bigGomainButtonImage);  // 버튼 생성자로 이미지를 넣어서 생성한다

		inputField = new JTextField(50);
		inputNumberField = new JTextField(50);
		placeInputField = new JTextField(50);
		password = new JTextArea(5,50);   // 텍스트필드와 에어리어의 크기를 생성한다 
		inputField.setFont(fieldFont);
		inputNumberField.setFont(fieldFont);  // 만든 폰트를 넣어준다
		password.setFont(passwordFont);
		placeInputField.setFont(fieldFont);
		inputNumberField.setText("0"); // 오류안나게 숫자를 넣어준다 

		

		backButton.setBorderPainted(false);
		backButton.setContentAreaFilled(false);
		backButton.setFocusPainted(false);     // 버튼 이미지를 png파일대로 보이게 하기 위한 코드
		backButton.setBounds(0,0,86,80);   // 버튼 위치
		exitButton.setBorderPainted(false);
		exitButton.setContentAreaFilled(false);
		exitButton.setFocusPainted(false);
		exitButton.setBounds(width-100, 0,86,80);
		inputField.setBounds(100,250,400,30);
		inputNumberField.setBounds(100,250,400,30);
		placeInputField.setBounds(100,250,400,30);
		inputFinishButton.setBorderPainted(false);
		inputFinishButton.setContentAreaFilled(false);
		inputFinishButton.setFocusPainted(false);
		inputFinishButton.setBounds(100,290,192,62);
		koreanBackButton.setBorderPainted(false);
		koreanBackButton.setContentAreaFilled(false);
		koreanBackButton.setFocusPainted(false);
		koreanBackButton.setBounds(300,290,192,62);
		password.setBounds(110,270,375,60);
		gomainButton.setBorderPainted(false);
		gomainButton.setContentAreaFilled(false);
		gomainButton.setFocusPainted(false);
		gomainButton.setBounds(300,360,192,62);
		saveFileButton.setBorderPainted(false);
		saveFileButton.setContentAreaFilled(false);
		saveFileButton.setFocusPainted(false);
		saveFileButton.setBounds(100,360,192,62);
		bigGomainButton.setBorderPainted(false);
		bigGomainButton.setContentAreaFilled(false);
		bigGomainButton.setFocusPainted(false);
		bigGomainButton.setBounds(140,300,300,70);
		this.requestFocus();
		setFocusable(true);


		backButton.addMouseListener(new MouseAdapter(){  //좌측상단 뒤로가기 버튼 이벤트  
			public void mousePressed(MouseEvent e) {  //클릭하였을때 
				if(makeScreen == 0) {   // 패널 첫 화면이면 메인패널로 돌아가게한다
				makeback = 1;
				inputField.setText("");
				inputNumberField.setText("0");
				backButton.setIcon(backButtonImage);
				backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
				if(makeScreen == 1) {   // 패널 두 번째 화면이면 첫 번째 화면으로 
					inputField.setVisible(true);
					inputNumberField.setVisible(false);
					makeScreen = 0;
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				
				}
				if(makeScreen == 2) {  // 패널 3번째 화면이면 2번째 화면으로 
					inputNumberField.setVisible(true);
					inputFinishButton.setVisible(true);
					koreanBackButton.setVisible(true);
					password.setVisible(false);
					gomainButton.setVisible(false);
				    saveFileButton.setVisible(false);
				    makeScreen =1;
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
				if(makeScreen == 3) {  // 패널 4번째 화면이면 3번째 화면으로 
				    password.setVisible(true);
				    saveFileButton.setVisible(true);
				    gomainButton.setVisible(true);
				    bigGomainButton.setVisible(false);
				    placeInputField.setVisible(false);
				    makeScreen =2;
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
			}
			public void mouseEntered(MouseEvent e) {    // 마우스가 버튼으로 들어갔을때 
				backButton.setIcon(backButtonEnteredImage);
				backButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			public void mouseExited(MouseEvent e) {  // 마우스가 버튼에서 나갔을 때 
				backButton.setIcon(backButtonImage);
				backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});


		this.addKeyListener(new KeyAdapter() {
			public void keyPressed(KeyEvent e) {
				int keycode = e.getKeyCode();
				if(keycode == KeyEvent.VK_BACK_SPACE) {
					if(makeScreen == 0) {   // 패널 첫 화면이면 메인패널로 돌아가게한다
						makeback = 1;
						inputField.setText("");
						inputNumberField.setText("0");
					}
						if(makeScreen == 1) {   // 패널 두 번째 화면이면 첫 번째 화면으로 
							inputField.setVisible(true);
							inputNumberField.setVisible(false);
							makeScreen = 0;
						}
						if(makeScreen == 2) {  // 패널 3번째 화면이면 2번째 화면으로 
							inputNumberField.setVisible(true);
							inputFinishButton.setVisible(true);
							koreanBackButton.setVisible(true);
							password.setVisible(false);
							gomainButton.setVisible(false);
						    saveFileButton.setVisible(false);
						    makeScreen =1;
						}
						if(makeScreen == 3) {  // 패널 4번째 화면이면 3번째 화면으로 
						    password.setVisible(true);
						    saveFileButton.setVisible(true);
						    gomainButton.setVisible(true);
						    bigGomainButton.setVisible(false);
						    placeInputField.setVisible(false);
						    makeScreen =2;
						}
				}
			}
		});

		inputField.addActionListener(e->{
			inputField.setVisible(false);  //  평문 입력 필드를 안보이게 하고 
			inputNumberField.setVisible(true);   // 패스워드 길이 필드를 보이게 한다 
			makeScreen = 1;  // 2번째 화면으로 전환
		});
		
		
		inputNumberField.addActionListener(e->{
		  // 두 번째 화면에서 눌렀을 때 
				passwordLength = Integer.parseInt(inputNumberField.getText());  // 스트링으로 입력한 패스워드 길이를 숫자로 바꿔준다
				if(passwordLength >= 4 && passwordLength <=20) {  // 4~20자리 숫자를 입력하였을 때만 정상적으로 실행
				inputFinishButton.setVisible(false); // 입력하기 버튼을 보이지 않게 한다   
				inputNumberField.setVisible(false);  // 숫자입력필드를 보이지 않게 한다 
				koreanBackButton.setVisible(false);  // 뒤로가기 버튼을 보이지 않게 한다 
				password.setVisible(true); // 생성된 패스워드가 입력될 텍스트에어리어를 보이게 한다 
				gomainButton.setVisible(true); // 메인으로 돌아가기 버튼을 보이게 한다 
				saveFileButton.setVisible(true); // 파일에 저장하기 버튼을 보이게 한다 
				inputFinishButton.setIcon(inputFinishButtonImage);  // 화면에서 나갔을때처럼 이미지와 커서를 돌려놓는다 
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				makeScreen = 2;   //3번째 화면으로 전환
				for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp배열을 초기화한다  
				for(i = 0;i < inputField.getText().length(); i++) { 
					tmp[i] =(int) inputField.getText().charAt(i);  // 입력한 평문 길이까지 tmp배열에  평문문자의 char의 숫자값을 넣는다 
				}
				
				
				passwordMake pm = new passwordMake();   // 해쉬암호식으로 각 자리수마다 암호를 만드는 메소드가 있는 객채를 생성한다 
				
				element[0] =(char) pm.oneChange(tmp, inputField.getText().length());
				element[1] =(char) pm.twoChange(tmp, inputField.getText().length());
				element[2] =(char) pm.threeChange(tmp, inputField.getText().length());
				element[3] =(char) pm.fourChange(tmp, inputField.getText().length());  //4~20자리여서 무조건 4자리는 되어서 각 자리에 맞는 메소드를 호출한다 
				
				if(passwordLength >= 5) 
					element[4] =(char) pm.fiveChange(tmp, inputField.getText().length());
				if(passwordLength >= 6) 
					element[5] =(char) pm.sixChange(tmp, inputField.getText().length());
				if(passwordLength >= 7) 
					element[6] =(char) pm.sevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 8) 
					element[7] =(char) pm.eightChange(tmp, inputField.getText().length());
				if(passwordLength >= 9) 
					element[8] =(char) pm.nineChange(tmp, inputField.getText().length());
				if(passwordLength >= 10) 
					element[9] =(char) pm.tenChange(tmp, inputField.getText().length());
				if(passwordLength >= 11) 
					element[10] =(char) pm.elevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 12) 
					element[11] =(char) pm.twelveChange(tmp, inputField.getText().length());
				if(passwordLength >= 13) 
					element[12] =(char) pm.thirteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 14) 
					element[13] =(char) pm.fourteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 15) 
					element[14] =(char) pm.fifteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 16) 
					element[15] =(char) pm.sixteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 17)
					element[16] =(char) pm.seventeenChange(tmp, inputField.getText().length());
				if(passwordLength >= 18)
					element[17] =(char) pm.eighteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 19)
					element[18] =(char) pm.nineteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 20)
					element[19] =(char) pm.twentyChange(tmp, inputField.getText().length());  //입력한 자리수까지 메소드를 실행한다 
				
				for(int i = 0; i < 20; i++)
					if(element[i] < 32)
					System.out.println((int) element[i]);
				element[0] =(char) ((element[0] % 10) + 48);  
				element[1] =(char) ((element[1] % 26) + 97);
				element[2] =(char) ((element[2] % 26) + 65);
				element[3] =(char) ((element[3] % 15) + 33); // 첫 4자리는 무조건 숫자,영소문자,영대문자 ,특수문자가 들어가게 한다 
								
				stringTemp = String.valueOf(element);  //char를 String으로 변환해준다 
				password.setText(stringTemp);  // 만들어진 패스워드를 텍스트에어리어에 넣어준다 
			    StringSelection stringSelection = new StringSelection(stringTemp);
			    Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
			    clipboard.setContents(stringSelection, null);  // 만들어지면 자동으로 클립보드에 복사가 된다 

			    stringTemp = inputField.getText();
				inputField.setText("");  
				inputNumberField.setText("0");    
				for(i = 0; i < 20; i++)
					element[i]  = 0;
				}// 다 이용한 변수를 다시 원상태로 복구시킨다 
			}
		);
		
		placeInputField.addActionListener(e->{
			makeScreen = 0;   //  화면0으로 전환한다 
			makeback = 1;  // 메인화면으로 간다 
		    bigGomainButton.setVisible(false);   
		    placeInputField.setVisible(false);
			backButton.setVisible(true);
			inputField.setVisible(true);
			inputFinishButton.setVisible(true);
			koreanBackButton.setVisible(true);   //메인에서 이 버튼 눌렀을 때 첫 화면이 나오게 한다 
			inputField.setText("");
			inputNumberField.setText("0");         
		    try {                                  
				File outFile= new File("out.txt");       //파일 객체를 만들고 
				if(!outFile.exists())outFile.createNewFile();  // 파일이 없으면 만들고 
				BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));  // 파일을 쓰는 객체를 만들고 파일 객체를 넣는다 
				if(placeInputField.getText().equals(""))  // 장소를 적지 않았으면
					bw.write("길이  : " + passwordLength + "    "+ "패스워드 : " + stringTemp); // 패스워드만 파일에 저장되고 
				else bw.write("사용할 장소 :  " + placeInputField.getText() + "    " + "길이 :   " + passwordLength + "    "  + " 패스워드  : " + stringTemp);  // 아니면 장소, 패스워드가 저장된다 
				bw.newLine();  // 입력하고 줄바꾼다 
				bw.close();   // 입력 완료후 파일 닫기 
		
		    
		    } catch (IOException e1) {
				e1.printStackTrace();
			}
		    placeInputField.setText("");
			
			
			
		});
		
		
		exitButton.addMouseListener(new MouseAdapter() {  // 우측상단 종료버튼 
			public void mousePressed(MouseEvent e) {  //클릭하면 종료된다
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) {  // 마우스가 버튼으로 들어가면 이미지와 커서가  바뀐다 
				exitButton.setIcon(exitButtonEnteredImage);
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {  // 마우스가 버튼 밖으로 나가면 이미지와 커서가 되돌아온다 
				exitButton.setIcon(exitButtonImage);
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		inputFinishButton.addMouseListener(new MouseAdapter() {  // 입력완료 버튼에 대한 마우스  이벤트처리 
			public void mousePressed(MouseEvent e) { // 마우스를 클릭하였을  때 
				if(makeScreen == 0) {  // 첫 번째 화면에서 입력 완료 눌렀을때 
				inputField.setVisible(false);  //  평문 입력 필드를 안보이게 하고 
				inputNumberField.setVisible(true);   // 패스워드 길이 필드를 보이게 한다 
				makeScreen = 1;  // 2번째 화면으로 전환
				inputFinishButton.setIcon(inputFinishButtonImage);   // 이미지 마우스 밖으로 나갔을때 처럼 되돌아오게 한다 
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));

				}
				else if(makeScreen == 1) {  // 두 번째 화면에서 눌렀을 때 
				passwordLength = Integer.parseInt(inputNumberField.getText());  // 스트링으로 입력한 패스워드 길이를 숫자로 바꿔준다
				if(passwordLength >= 4 && passwordLength <=20) {  // 4~20자리 숫자를 입력하였을 때만 정상적으로 실행
				inputFinishButton.setVisible(false); // 입력하기 버튼을 보이지 않게 한다   
				inputNumberField.setVisible(false);  // 숫자입력필드를 보이지 않게 한다 
				koreanBackButton.setVisible(false);  // 뒤로가기 버튼을 보이지 않게 한다 
				password.setVisible(true); // 생성된 패스워드가 입력될 텍스트에어리어를 보이게 한다 
				gomainButton.setVisible(true); // 메인으로 돌아가기 버튼을 보이게 한다 
				saveFileButton.setVisible(true); // 파일에 저장하기 버튼을 보이게 한다 
				inputFinishButton.setIcon(inputFinishButtonImage);  // 화면에서 나갔을때처럼 이미지와 커서를 돌려놓는다 
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				
				makeScreen = 2;   //3번째 화면으로 전환
				for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp배열을 초기화한다  
				for(i = 0;i < inputField.getText().length(); i++) { 
					tmp[i] =(int) inputField.getText().charAt(i);  // 입력한 평문 길이까지 tmp배열에  평문문자의 char의 숫자값을 넣는다 
				}
				
				
				passwordMake pm = new passwordMake();   // 해쉬암호식으로 각 자리수마다 암호를 만드는 메소드가 있는 객채를 생성한다 
				
				element[0] =(char) pm.oneChange(tmp, inputField.getText().length());
				element[1] =(char) pm.twoChange(tmp, inputField.getText().length());
				element[2] =(char) pm.threeChange(tmp, inputField.getText().length());
				element[3] =(char) pm.fourChange(tmp, inputField.getText().length());  //4~20자리여서 무조건 4자리는 되어서 각 자리에 맞는 메소드를 호출한다 
				
				if(passwordLength >= 5) 
					element[4] =(char) pm.fiveChange(tmp, inputField.getText().length());
				if(passwordLength >= 6) 
					element[5] =(char) pm.sixChange(tmp, inputField.getText().length());
				if(passwordLength >= 7) 
					element[6] =(char) pm.sevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 8) 
					element[7] =(char) pm.eightChange(tmp, inputField.getText().length());
				if(passwordLength >= 9) 
					element[8] =(char) pm.nineChange(tmp, inputField.getText().length());
				if(passwordLength >= 10) 
					element[9] =(char) pm.tenChange(tmp, inputField.getText().length());
				if(passwordLength >= 11) 
					element[10] =(char) pm.elevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 12) 
					element[11] =(char) pm.twelveChange(tmp, inputField.getText().length());
				if(passwordLength >= 13) 
					element[12] =(char) pm.thirteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 14) 
					element[13] =(char) pm.fourteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 15) 
					element[14] =(char) pm.fifteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 16) 
					element[15] =(char) pm.sixteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 17)
					element[16] =(char) pm.seventeenChange(tmp, inputField.getText().length());
				if(passwordLength >= 18)
					element[17] =(char) pm.eighteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 19)
					element[18] =(char) pm.nineteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 20)
					element[19] =(char) pm.twentyChange(tmp, inputField.getText().length());  //입력한 자리수까지 메소드를 실행한다 
				
				for(int i = 0; i < 20; i++)
					if(element[i] < 32)
					System.out.println((int) element[i]);
				element[0] =(char) ((element[0] % 10) + 48);  
				element[1] =(char) ((element[1] % 26) + 97);
				element[2] =(char) ((element[2] % 26) + 65);
				element[3] =(char) ((element[3] % 15) + 33); // 첫 4자리는 무조건 숫자,영소문자,영대문자 ,특수문자가 들어가게 한다 
								
				stringTemp = String.valueOf(element);  //char를 String으로 변환해준다 
				password.setText(stringTemp);  // 만들어진 패스워드를 텍스트에어리어에 넣어준다 
			    StringSelection stringSelection = new StringSelection(stringTemp);
			    Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
			    clipboard.setContents(stringSelection, null);  // 만들어지면 자동으로 클립보드에 복사가 된다 

			    
			    stringTemp = inputField.getText();
				inputField.setText("");  
				inputNumberField.setText("0"); 
				for(i = 0; i < 20; i++)
					element[i]  = 0;
				}// 다 이용한 변수를 다시 원상태로 복구시킨다 
			}
			}
			@Override
			public void mouseEntered(MouseEvent e) {// 마우스가 버튼안으로 들어가면 이미지와 커서가 바뀐다 
				inputFinishButton.setIcon(inputFinishButtonEnteredImage);
				inputFinishButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {  // 마우스가 버튼밖으로 나가면 이미지와 커서가 되돌아온다 
				inputFinishButton.setIcon(inputFinishButtonImage);
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		
		koreanBackButton.addMouseListener(new MouseAdapter() {  //뒤로가기 버튼을 눌렀을 때 마우스 이벤트 
			public void mousePressed(MouseEvent e) {  // 뒤로가기 버튼을 클릭하였을 때 
				if(makeScreen == 0) { // 첫 번째 화면이면 메인패널로 돌아간다 
				makeback = 1;
				koreanBackButton.setIcon(koreanBackButtonImage);
				koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				inputField.setText("");
				inputNumberField.setText("0");
				}
				if(makeScreen == 1) {  // 두번째 화면이면 1번쨰 화면으로 돌아간다 
					inputField.setVisible(true);
					inputNumberField.setVisible(false);
					makeScreen = 0;
					koreanBackButton.setIcon(koreanBackButtonImage);
					koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
			}
			@Override
			public void mouseEntered(MouseEvent e) {  // 마우스가 버튼 안으로 들어가면 이미지와 커서가 바뀐다 
				koreanBackButton.setIcon(koreanBackButtonEnteredImage);
				koreanBackButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {  // 마우스가 버튼 밖으로 나가면 이미지와 커서가 되돌아온다 
				koreanBackButton.setIcon(koreanBackButtonImage);
				koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
	
		gomainButton.addMouseListener(new MouseAdapter() {   // 메인으로 돌아가기 버튼을 클릭했을때 
			public void mousePressed(MouseEvent e) {// 버튼을 클릭하였을때 
				makeback = 1;   // 메인화면으로 
				gomainButton.setIcon(gomainButtonImage);  // 화면밖으로 나간거처럼 화면을 바꾼다 
				gomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				backButton.setVisible(true);         
				inputField.setVisible(true);
				inputFinishButton.setVisible(true);
				koreanBackButton.setVisible(true);
				password.setVisible(false);
				gomainButton.setVisible(false);
				saveFileButton.setVisible(false); // 다시 패스워드 만들기 버튼을 눌렀을때 첫번째 화면이 제대로 나오게 한다 
				makeScreen =0;
				passwordLength = 0;
			}
			@Override
			public void mouseEntered(MouseEvent e) {// 마우스가 버튼 안으로 들어가면 이미지와 커서가 바뀐다 
				gomainButton.setIcon(gomainButtonEnteredImage);
				gomainButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// 마우스가 버튼 밖으로 나가면 이미지와 커서가 되돌아온다 
				gomainButton.setIcon(gomainButtonImage);
				gomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
	
		
		saveFileButton.addMouseListener(new MouseAdapter() {  //저장하기 버튼을 눌렀을 때 마우스 이벤트 
			public void mousePressed(MouseEvent e) { // 버튼을 클릭하였을 때 
				makeScreen = 3;  // 이미지를 4번째 화면껄로 바꿔준다 
			    password.setVisible(false);  // 생성된 패스워드를 안보이게 한다 
			    saveFileButton.setVisible(false); // 저장하기 버튼을 안보이게 한다 
			    gomainButton.setVisible(false);   //  메인으로 가기 버튼을 안보이게 한다 
			    bigGomainButton.setVisible(true);  //  저장완료하고 메인으로 돌아가는 버튼을 보이게 한다 
			    placeInputField.setVisible(true);   //  어디에서 이용할지 입력하는 텍스트필드를 보이게 한다 
				saveFileButton.setIcon(saveFileButtonImage);
				saveFileButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
			@Override
			public void mouseEntered(MouseEvent e) {// 마우스가 버튼 안으로 들어가면 이미지와 커서가 바뀐다 
				saveFileButton.setIcon(saveFileButtonEnteredImage);
				saveFileButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// 마우스가 버튼 밖으로 나가면 이미지와 커서가 되돌아온다 
				saveFileButton.setIcon(saveFileButtonImage);
				saveFileButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		bigGomainButton.addMouseListener(new MouseAdapter() {    // 저장하고 메인으로 돌아가기 버튼을 눌렀을때 마우스 이벤트 
			public void mousePressed(MouseEvent e) {    // 마우스가 클릭되었을 떄 일어날 이벤트
				makeScreen = 0;   //  화면0으로 전환한다 
				makeback = 1;  // 메인화면으로 간다 
			    bigGomainButton.setVisible(false);   
			    placeInputField.setVisible(false);
				backButton.setVisible(true);
				inputField.setVisible(true);
				inputFinishButton.setVisible(true);
				koreanBackButton.setVisible(true);   //메인에서 이 버튼 눌렀을 때 첫 화면이 나오게 한다 
				inputField.setText("");
				inputNumberField.setText("0");         
			    try {                                  
					File outFile= new File("out.txt");       //파일 객체를 만들고 
					if(!outFile.exists())outFile.createNewFile();  // 파일이 없으면 만들고 
					BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));  // 파일을 쓰는 객체를 만들고 파일 객체를 넣는다 
					if(placeInputField.getText().equals(""))  // 장소를 적지 않았으면
						bw.write("길이  : " + passwordLength + "    "+ "패스워드 : " + stringTemp); // 패스워드만 파일에 저장되고 
					else bw.write("사용할 장소 :  " + placeInputField.getText() + "    " + "길이   :   " 
						+ passwordLength + "    "  + " 패스워드  : " + stringTemp);  // 아니면 장소, 패스워드가 저장된다 
					bw.newLine();  // 입력하고 줄바꾼다 
					bw.close();   // 입력 완료후 파일 닫기 
				} catch (IOException e1) {
					e1.printStackTrace();
				}
			    placeInputField.setText("");
			    bigGomainButton.setIcon(bigGomainButtonImage);
			    bigGomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));

			}
			@Override
			public void mouseEntered(MouseEvent e) {// 마우스가 버튼 안으로 들어가면 이미지와 커서가 바뀐다 
				bigGomainButton.setIcon(bigGomainButtonEnteredImage);
				bigGomainButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// 마우스가 버튼 밖으로 나가면 이미지와 커서가 되돌아온다 
				bigGomainButton.setIcon(bigGomainButtonImage);
				bigGomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		this.add(backButton);
		this.add(exitButton);
		this.add(inputField);
		this.add(inputFinishButton);
		this.add(koreanBackButton);
		this.add(password);
		this.add(gomainButton);
		this.add(inputNumberField);
		this.add(saveFileButton);
		this.add(bigGomainButton);
		this.add(placeInputField);  // 컴포넌트들을 패널에 추가시킨다 
		password.setVisible(false);
		gomainButton.setVisible(false);
		inputNumberField.setVisible(false);
		saveFileButton.setVisible(false);
		bigGomainButton.setVisible(false);
		placeInputField.setVisible(false);  // 첫 화면에 보일 필요 없는 컴포넌트들은 setVisible(false)한다 

	}
	
	
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		if(makeScreen ==0) {    // makeScreen의 숫자가 달라지면 보여지는 이미지가 달라지게 하고 repaint한다 
		g.drawImage(order, 100,150,null);
		repaint();
		}
		if(makeScreen == 1) {
			g.drawImage(numberOrder,100,150,null);
			repaint();
		}
		if(makeScreen ==2) {
		g.drawImage(finishText, 100,150,null);
		g.drawImage(passwordBackground,100,260,null);
		repaint();
		}
		if(makeScreen ==3) {
		g.drawImage(placeOrder, 100,150,null);
		repaint();
		}
	}
	
	
}
