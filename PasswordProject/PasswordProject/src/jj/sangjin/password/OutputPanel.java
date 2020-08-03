package jj.sangjin.password;

import java.awt.Cursor;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Toolkit;
import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.StringSelection;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class OutputPanel extends JPanel{
	private static int width = 600;
	private static int height = 500;
	
	protected int count = 0;
	protected int tcount = 0;
	protected int outputBack = 0;  // 1이되면 메인화면으로 돌아가는 ㅂ변수 
	private JButton backButton;
	private JButton exitButton;
	private JButton f5;
	private JTextArea password;
	private JLabel l1;
	private Font font;   // 컴포넌트 생성 .
	
	
	private int[] tmp = new int[50];    //  input에 입력한 글자의 숫자값을 저장하는 배열
	private int i = 0;   // 반복문 돌기위한 변수
	private char[] element = new char[20];  // tmp의 숫자로 난수를 만들어 그 난수를 받은 것을 아스키 코드로 해서 만든 문자를 저장하는 배열
	private String Stringtemp = null;  // element배열을 조합만 문장을 저장하는 변수
	private int passwordLength;   // 비밀번호 길이를 얼마로 할지 사용자가 입력할 변수 
	
	private ImageIcon backButtonImage = new ImageIcon("back.png");
	private ImageIcon backButtonEnteredImage = new ImageIcon("backEntered.png");
	private ImageIcon exitButtonImage = new ImageIcon("exit.png");
	private ImageIcon exitButtonEnteredImage = new ImageIcon("exitEntered.png");  // 버튼에 넣을 이미지아이콘 
	private BufferedImage outputImage;  // 중앙쪽에 보일 이미지 
	
	
	public OutputPanel() {
		

		this.setLayout(null);
		
		backButton = new JButton(backButtonImage);
		exitButton = new JButton(exitButtonImage);   // 버튼에 이미지아이콘 넣고 생성 
		f5 = new JButton("F5");   // 새로고침할 버튼 
		password = new JTextArea(50,500);      // TextArea 생성 
		JScrollPane scroll = new JScrollPane(password);  // TextArea에 스크롤기능 추가 
		
	    try {
	    	outputImage = ImageIO.read(new File("outputImage.png"));
			File outFile= new File("out.txt");
			if(!outFile.exists())outFile.createNewFile();
			Scanner s = new Scanner(new BufferedReader(new FileReader(outFile)));
			String passwordTemp;
			while(s.hasNext()) {
				passwordTemp = s.next();
				if(passwordTemp.equals("길이")) {
					count++;
					continue;
				}
				
				else if(count == 1) {
					count++;
					continue;
				}
				else if(count == 2) {
					passwordLength = Integer.parseInt(passwordTemp);
					count++;	
					continue;
				}
				else if(count == 3 && passwordTemp.equals(":")) {
					count++;
				}
				else if(count == 4) {
					for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp배열을 초기화한다  
					for(i = 0; i < 20; i++)
						element[i]  = 0;
					for(i = 0;i < passwordTemp.length(); i++) { 
						tmp[i] =(int) passwordTemp.charAt(i);  // 입력한 평문 길이까지 tmp배열에  평문문자의 char의 숫자값을 넣는다 
					}
					
					
					passwordMake pm = new passwordMake();   // 해쉬암호식으로 각 자리수마다 암호를 만드는 메소드가 있는 객채를 생성한다 
					
					element[0] =(char) pm.oneChange(tmp, passwordTemp.length());
					element[1] =(char) pm.twoChange(tmp, passwordTemp.length());
					element[2] =(char) pm.threeChange(tmp, passwordTemp.length());
					element[3] =(char) pm.fourChange(tmp, passwordTemp.length());  //4~20자리여서 무조건 4자리는 되어서 각 자리에 맞는 메소드를 호출한다 
					
					if(passwordLength >= 5) 
						element[4] =(char) pm.fiveChange(tmp, passwordTemp.length());
					if(passwordLength >= 6) 
						element[5] =(char) pm.sixChange(tmp, passwordTemp.length());
					if(passwordLength >= 7) 
						element[6] =(char) pm.sevenChange(tmp, passwordTemp.length());
					if(passwordLength >= 8) 
						element[7] =(char) pm.eightChange(tmp, passwordTemp.length());
					if(passwordLength >= 9) 
						element[8] =(char) pm.nineChange(tmp, passwordTemp.length());
					if(passwordLength >= 10) 
						element[9] =(char) pm.tenChange(tmp, passwordTemp.length());
					if(passwordLength >= 11) 
						element[10] =(char) pm.elevenChange(tmp, passwordTemp.length());
					if(passwordLength >= 12) 
						element[11] =(char) pm.twelveChange(tmp, passwordTemp.length());
					if(passwordLength >= 13) 
						element[12] =(char) pm.thirteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 14) 
						element[13] =(char) pm.fourteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 15) 
						element[14] =(char) pm.fifteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 16) 
						element[15] =(char) pm.sixteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 17)
						element[16] =(char) pm.seventeenChange(tmp, passwordTemp.length());
					if(passwordLength >= 18)
						element[17] =(char) pm.eighteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 19)
						element[18] =(char) pm.nineteenChange(tmp, passwordTemp.length());
					if(passwordLength >= 20)
						element[19] =(char) pm.twentyChange(tmp, passwordTemp.length());  //입력한 자리수까지 메소드를 실행한다 

					element[0] =(char) ((char)((char)element[0] % 10) + 48);  
					element[1] =(char) ((char)((char)element[1] % 26) + 97);
					element[2] =(char) ((char)((char)element[2] % 26) + 65);
					element[3] =(char) ((char)((char)element[3] % 15) + 33); // 첫 4자리는 무조건 숫자,영소문자,영대문자 ,특수문자가 들어가게 한다 
									
					Stringtemp = String.valueOf(element);  //char를 String으로 변환해준다 

				    count = 0;
					password.append(Stringtemp + "\n");
					passwordLength = 0;
					tcount = 0;
					continue;
					}// 다 이용한 변수를 다시 원상태로 복구시킨다 
				
				if(passwordTemp.equals("패스워드") && count == 0) {
					tcount++;
				}
				else if(tcount == 1) {
					tcount++;
				}
				else if(tcount == 2) {
					password.append(passwordTemp + "\n");
					tcount = 0;
					continue;
					
				}
				password.append(passwordTemp + "  ");
	    }
			s.close();   // 이미지를 추가하고 파일을 불러와서 TextArea에 추가한다 
		} catch (IOException e1) {
			e1.printStackTrace();
		}

		scroll.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
		scroll.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);  // 스크롤에 스크롤바 추가 
		

		backButton.setBorderPainted(false);
		backButton.setContentAreaFilled(false);
		backButton.setFocusPainted(false);
		backButton.setBounds(0,0,86,80);
		exitButton.setBorderPainted(false);
		exitButton.setContentAreaFilled(false);
		exitButton.setFocusPainted(false);
		exitButton.setBounds(width-100,0,86,80);
		scroll.setBounds(132,200,325,200);
		f5.setBounds(50,250,50,50);  // 컴포넌트 배치 
		
		backButton.addMouseListener(new MouseAdapter(){  // 좌측상단 뒤로가기 버튼에 대한 마우스 이벤트 
			public void mousePressed(MouseEvent e) {
					outputBack = 1;  // 클릭하면 메인패널로 
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));	
			}

			public void mouseEntered(MouseEvent e) {
				backButton.setIcon(backButtonEnteredImage);
				backButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			public void mouseExited(MouseEvent e) {
				backButton.setIcon(backButtonImage);
				backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		exitButton.addMouseListener(new MouseAdapter() {   // 우측상단 종료하기 버튼에 대한 마우스 이벤트 처리 
			public void mousePressed(MouseEvent e) {  // 클릭시 종료 
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) {
				exitButton.setIcon(exitButtonEnteredImage);
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {
				exitButton.setIcon(exitButtonImage);
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		f5.addMouseListener(new MouseAdapter() {   // 새로고침 버튼에 대한 마우스 이벤트 처리 
			public void mousePressed(MouseEvent e) { // 클릭시 
				try {
					password.setText("");
			    	outputImage = ImageIO.read(new File("outputImage.png"));
					File outFile= new File("out.txt");
					if(!outFile.exists())outFile.createNewFile();
					Scanner s = new Scanner(new BufferedReader(new FileReader(outFile)));
					String passwordTemp;
					while(s.hasNext()) {
						
						passwordTemp = s.next();
						if(passwordTemp.equals("길이")) {
							count++;
							continue;
						}
						
						else if(count == 1) {
							count++;
							continue;
						}
						else if(count == 2) {
							passwordLength = Integer.parseInt(passwordTemp);
							count++;	
							continue;
						}
						else if(count == 3 && passwordTemp.equals(":")) {
							count++;
						}
						else if(count == 4) {
							for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp배열을 초기화한다  
							for(i = 0; i < 20; i++)
								element[i]  = 0;
							for(i = 0;i < passwordTemp.length(); i++) { 
								tmp[i] =(int) passwordTemp.charAt(i);  // 입력한 평문 길이까지 tmp배열에  평문문자의 char의 숫자값을 넣는다 
							}
							
							
							passwordMake pm = new passwordMake();   // 해쉬암호식으로 각 자리수마다 암호를 만드는 메소드가 있는 객채를 생성한다 
							
							element[0] =(char) pm.oneChange(tmp, passwordTemp.length());
							element[1] =(char) pm.twoChange(tmp, passwordTemp.length());
							element[2] =(char) pm.threeChange(tmp, passwordTemp.length());
							element[3] =(char) pm.fourChange(tmp, passwordTemp.length());  //4~20자리여서 무조건 4자리는 되어서 각 자리에 맞는 메소드를 호출한다 
							
							if(passwordLength >= 5) 
								element[4] =(char) pm.fiveChange(tmp, passwordTemp.length());
							if(passwordLength >= 6) 
								element[5] =(char) pm.sixChange(tmp, passwordTemp.length());
							if(passwordLength >= 7) 
								element[6] =(char) pm.sevenChange(tmp, passwordTemp.length());
							if(passwordLength >= 8) 
								element[7] =(char) pm.eightChange(tmp, passwordTemp.length());
							if(passwordLength >= 9) 
								element[8] =(char) pm.nineChange(tmp, passwordTemp.length());
							if(passwordLength >= 10) 
								element[9] =(char) pm.tenChange(tmp, passwordTemp.length());
							if(passwordLength >= 11) 
								element[10] =(char) pm.elevenChange(tmp, passwordTemp.length());
							if(passwordLength >= 12) 
								element[11] =(char) pm.twelveChange(tmp, passwordTemp.length());
							if(passwordLength >= 13) 
								element[12] =(char) pm.thirteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 14) 
								element[13] =(char) pm.fourteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 15) 
								element[14] =(char) pm.fifteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 16) 
								element[15] =(char) pm.sixteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 17)
								element[16] =(char) pm.seventeenChange(tmp, passwordTemp.length());
							if(passwordLength >= 18)
								element[17] =(char) pm.eighteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 19)
								element[18] =(char) pm.nineteenChange(tmp, passwordTemp.length());
							if(passwordLength >= 20)
								element[19] =(char) pm.twentyChange(tmp, passwordTemp.length());  //입력한 자리수까지 메소드를 실행한다 

							element[0] =(char) ((char)((char)element[0] % 10) + 48);  
							element[1] =(char) ((char)((char)element[1] % 26) + 97);
							element[2] =(char) ((char)((char)element[2] % 26) + 65);
							element[3] =(char) ((char)((char)element[3] % 15) + 33); // 첫 4자리는 무조건 숫자,영소문자,영대문자 ,특수문자가 들어가게 한다 
											
							Stringtemp = String.valueOf(element);  //char를 String으로 변환해준다 
						    count = 0;
						    tcount = 0;
							password.append(Stringtemp + "\n");
							continue;
							}// 다 이용한 변수를 다시 원상태로 복구시킨다 
						
						if(passwordTemp.equals("패스워드")) {
							tcount++;
						}
						else if(tcount == 1) {
							tcount++;
						}
						else if(tcount == 2) {
							password.append(passwordTemp + "\n");
							tcount = 0;
							continue;
							
						}
						password.append(passwordTemp + "  ");
					}
					s.close();
				} catch (IOException e1) {
					e1.printStackTrace();
				}
			    }
			@Override
			public void mouseEntered(MouseEvent e) {
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		this.add(exitButton);
		this.add(backButton);
		this.add(scroll);
		this.add(f5);  // 만든 컴포넌트 추가 

		
	}
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		g.drawImage(outputImage,110, 120, 350, 70,null);  // 이미지 추가 
	}
		
	
}
