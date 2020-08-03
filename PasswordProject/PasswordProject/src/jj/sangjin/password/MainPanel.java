package jj.sangjin.password;

import java.awt.Color;
import java.awt.Cursor;
import java.awt.Font;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;

public class MainPanel extends JPanel{
	protected int menu1 = 0;    // 만들기버튼 눌렀을때 바뀌는 숫자
	protected int menu2 = 0;    // 입력하기 버튼 눌렀을때 바뀌는 숫자
	protected int menu3 = 0;    // 불러오기 버튼 눌렀을때 바뀌는 숫자
	private static int width = 600;  // 화면 크기
	private static int height = 500;
	protected int count = 0;

	private JButton makeButton;      //만들기패널로 가기위한 버튼
	private JButton inputButton;   // 입력하기 패넗로 가기위한 버튼
	private JButton outputButton;  // 불러오기 패널로 가기위한 버튼
	private JButton underExitButton;  //밑에있는 종료하기버튼
	private JButton exitButton;  // 우측상단 종료하기 버튼
	
	private ImageIcon makeButtonEnteredImage = new ImageIcon("makeEntered.png");
	private ImageIcon makeButtonImage = new ImageIcon("make.png");
	private ImageIcon inputButtonImage = new ImageIcon("input.png");
	private ImageIcon inputButtonEnteredImage = new ImageIcon("inputEntered.png");
	private ImageIcon outputButtonImage = new ImageIcon("output.png");
	private ImageIcon outputButtonEnteredImage = new ImageIcon("outputEntered.png");
	private ImageIcon underExitButtonImage = new ImageIcon("underExit.png");
	private ImageIcon underExitButtonEnteredImage = new ImageIcon("underExitEntered.png");
	private ImageIcon exitButtonImage = new ImageIcon("exit.png");
	private ImageIcon exitButtonEnteredImage = new ImageIcon("exitEntered.png");    // 만든 png파일 이미지 객체를 만들어준다
	
	private JLabel appName1;
	private JLabel appName2;
	private JLabel appName3;
	private JLabel appName4;
	private JLabel appName5;
	private JLabel appName6;
	private JLabel appName7;
	
	private Font font = new Font("serif",Font.BOLD,30);
	
		public MainPanel() {
			
		this.setLayout(null);  // 레이아웃은 널로
		makeButton = new JButton(makeButtonImage);
		inputButton = new JButton(inputButtonImage);
		outputButton = new JButton(outputButtonImage);
		underExitButton = new JButton(underExitButtonImage);
		exitButton = new JButton(exitButtonImage);  // 이미지객체를 버튼에 넣어준다
		appName1 = new JLabel("패");
		appName2 = new JLabel("스");
		appName3 = new JLabel("워");
		appName4 = new JLabel("드");
		appName5 = new JLabel("생");
		appName6 = new JLabel("성");
		appName7 = new JLabel("기");
		appName1.setFont(font);
		appName2.setFont(font);
		appName3.setFont(font);
		appName4.setFont(font);
		appName5.setFont(font);
		appName6.setFont(font);
		appName7.setFont(font);
		
		

		makeButton.setBounds(200,150,190,60);   // 버튼 위치
		makeButton.setBorderPainted(false);   
		makeButton.setContentAreaFilled(false);
		makeButton.setFocusPainted(false);    // 위 3개는 이미지 그대로 보이게 하기 위한 코드
		inputButton.setBorderPainted(false);
		inputButton.setContentAreaFilled(false);
		inputButton.setFocusPainted(false);
		inputButton.setBounds(200,220,190,60);
		outputButton.setBorderPainted(false);
		outputButton.setContentAreaFilled(false);
		outputButton.setFocusPainted(false);
		outputButton.setBounds(200,290,190,60);
		underExitButton.setBorderPainted(false);
		underExitButton.setContentAreaFilled(false);
		underExitButton.setFocusPainted(false);
		underExitButton.setBounds(200,360,190,60);
		exitButton.setBounds(width-100, 0,86,80);
		exitButton.setBorderPainted(false);
		exitButton.setContentAreaFilled(false);
		exitButton.setFocusPainted(false);

		appName1.setBounds(100,30,40,40);
		appName2.setBounds(130,35,40,40);
		appName3.setBounds(160,40,40,40);
		appName4.setBounds(190,35,40,40);
		appName5.setBounds(220,30,40,40);
		appName6.setBounds(250,35,40,40);
		appName7.setBounds(280,40,40,40);
		
		appName1.setVisible(false);
		appName2.setVisible(false);
		appName3.setVisible(false);
		appName4.setVisible(false);
		appName5.setVisible(false);
		appName6.setVisible(false);
		appName7.setVisible(false);
		
		
		appName1.setForeground(Color.BLACK);
		appName2.setForeground(Color.BLACK);
		appName3.setForeground(Color.BLACK);
		appName4.setForeground(Color.BLACK);
		appName5.setForeground(Color.BLACK);
		appName6.setForeground(Color.BLACK);
		appName7.setForeground(Color.BLACK);
		

		
		makeButton.addMouseListener(new MouseAdapter() {   // 패스워드 만들기 버튼에 대한 마우스 리스너
				public void mousePressed(MouseEvent e) {   // 클릭 시 화면전환을 위해 menu1을 1로 바꾸고 마우스 올려노면 색 바뀌는 것을 돌려놓는다
 					menu1 = 1;   
					makeButton.setIcon(makeButtonImage);
					makeButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
				@Override
				public void mouseEntered(MouseEvent e) {  // 마우스가 올라가면 커서와 이미지가 바뀐다 
					makeButton.setIcon(makeButtonEnteredImage);
					makeButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
				}
				@Override
				public void mouseExited(MouseEvent e) {  // 마우스가 다시 밖으로 나가면 원래대로 돌아온다
					makeButton.setIcon(makeButtonImage);
					makeButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
		});
		
		inputButton.addMouseListener(new MouseAdapter() {// 패스워드 입력하기 버튼에 대한 마우스 리스너
			public void mousePressed(MouseEvent e) {// 클릭 시 화면전환을 위해 menu2을 1로 바꾸고 마우스 올려노면 색 바뀌는 것을 돌려놓는다
				menu2 = 1;
				inputButton.setIcon(inputButtonImage);
				inputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
			@Override
			public void mouseEntered(MouseEvent e) { // 마우스가 올라가면 커서와 이미지가 바뀐다 
				inputButton.setIcon(inputButtonEnteredImage);
				inputButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// 마우스가 다시 밖으로 나가면 원래대로 돌아온다
				inputButton.setIcon(inputButtonImage);
				inputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
	});
	
		outputButton.addMouseListener(new MouseAdapter() {// 패스워드 불러오기 버튼에 대한 마우스 리스너
			public void mousePressed(MouseEvent e) {// 클릭 시 화면전환을 위해 menu3을 1로 바꾸고 마우스 올려노면 색 바뀌는 것을 돌려놓는다
				menu3 = 1;
				outputButton.setIcon(outputButtonImage);
				outputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
			@Override
			public void mouseEntered(MouseEvent e) { // 마우스가 올라가면 커서와 이미지가 바뀐다 
				outputButton.setIcon(outputButtonEnteredImage);
				outputButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// 마우스가 다시 밖으로 나가면 원래대로 돌아온다
				outputButton.setIcon(outputButtonImage);
				outputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
	});
		
		underExitButton.addMouseListener(new MouseAdapter() {// 패스워드 종료하기 버튼에 대한 마우스 리스너
			public void mousePressed(MouseEvent e) {  // 누르면 프로그램이 종료된다 
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) { // 마우스가 올라가면 커서와 이미지가 바뀐다 
				underExitButton.setIcon(underExitButtonEnteredImage);
				underExitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {	 // 마우스가 다시 밖으로 나가면 원래대로 돌아온다
				underExitButton.setIcon(underExitButtonImage);
				underExitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
	});
		
		
		exitButton.addMouseListener(new MouseAdapter() {// 우측상단 패스워드 종료하기 버튼에 대한 마우스 리스너
			public void mousePressed(MouseEvent e) {// 누르면 프로그램이 종료된다 
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) {// 마우스가 올라가면 커서와 이미지가 바뀐다 
				exitButton.setIcon(exitButtonEnteredImage);
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// 마우스가 다시 밖으로 나가면 원래대로 돌아온다
				exitButton.setIcon(exitButtonImage);
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		this.add(makeButton);
		this.add(inputButton);
		this.add(outputButton);
		this.add(underExitButton);
		this.add(exitButton);   // 버튼들을 패널에 추가해준다 
		this.add(appName1);
		this.add(appName2);
		this.add(appName3);
		this.add(appName4);
		this.add(appName5);
		this.add(appName6);
		this.add(appName7);
		

	}
		public Thread threadMake() {
			return new Thread(new MyThread());
		}
		
		public void threadStop(Thread t) {
			t.interrupt();
		}
		
		class MyThread extends Thread{
			public void run() {
				try {
					while(true) {
						count++;
						if(count == 1) {
							appName1.setVisible(true);
						}
						else if(count == 2) {
							appName2.setVisible(true);
						}
						else if(count == 3) {
							appName3.setVisible(true);
						}
						else if(count == 4) {
							appName4.setVisible(true);
						}
						else if(count == 5) {
							appName5.setVisible(true);
						}
						else if(count == 6) {
							appName6.setVisible(true);
						}
						else if(count == 7) {
							appName7.setVisible(true);
						}
						else if(count == 8) {
							appName1.setBounds(110,30,40,40);
							appName2.setBounds(140,35,40,40);
							appName3.setBounds(170,40,40,40);
							appName4.setBounds(200,35,40,40);
							appName5.setBounds(230,30,40,40);
							appName6.setBounds(260,35,40,40);
							appName7.setBounds(290,40,40,40);
						}
						else if(count == 9) {
							appName1.setBounds(120,40,40,40);
							appName2.setBounds(150,45,40,40);
							appName3.setBounds(180,50,40,40);
							appName4.setBounds(210,45,40,40);
							appName5.setBounds(240,40,40,40);
							appName6.setBounds(270,45,40,40);
							appName7.setBounds(300,50,40,40);
						}
						else if(count == 10) {
							appName1.setBounds(130,30,40,40);
							appName2.setBounds(160,35,40,40);
							appName3.setBounds(190,40,40,40);
							appName4.setBounds(220,35,40,40);
							appName5.setBounds(250,30,40,40);
							appName6.setBounds(280,35,40,40);
							appName7.setBounds(310,40,40,40);
						}
						else if(count == 11) {
							appName1.setBounds(140,30,40,40);
							appName2.setBounds(170,35,40,40);
							appName3.setBounds(200,40,40,40);
							appName4.setBounds(230,35,40,40);
							appName5.setBounds(260,30,40,40);
							appName6.setBounds(290,35,40,40);
							appName7.setBounds(320,40,40,40);
						}
						else if(count == 12) {
							appName1.setBounds(100,30,40,40);
							appName2.setBounds(130,35,40,40);
							appName3.setBounds(160,40,40,40);
							appName4.setBounds(190,35,40,40);
							appName5.setBounds(220,30,40,40);
							appName6.setBounds(250,35,40,40);
							appName7.setBounds(280,40,40,40);
							appName1.setVisible(false);
							appName2.setVisible(false);
							appName3.setVisible(false);
							appName4.setVisible(false);
							appName5.setVisible(false);
							appName6.setVisible(false);
							appName7.setVisible(false);
							count = 0;
						}
						
						Thread.sleep(500);
					}
				}catch(Exception e) {}
			}
			
			
		}
		
}
