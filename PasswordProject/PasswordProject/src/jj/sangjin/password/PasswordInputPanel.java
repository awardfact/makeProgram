package jj.sangjin.password;

import java.awt.Cursor;
import java.awt.Font;
import java.awt.Graphics;
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
import javax.swing.JTextField;

public class PasswordInputPanel extends JPanel{
	private static int width = 600;
	private static int height = 500;
	private int inputScreen  = 0;  // 패널의 몇번째 화면인지 나타내는 변수 
	
	private JButton backButton;
	private JButton exitButton;
	private JButton inputFinishButton;
	private JButton koreanBackButton;
	private JButton bigGomainButton;
	private JTextField placeInputField;
	private JTextField passwordInputField;
	private Font fieldFont;      // 입력하기 패널에 필요한 컴포넌트들을 만든다 
	protected int inputBack = 0;   // 1이되면 메인패널로 돌아가는 변수 
	
	private BufferedImage placeOrder;
	private BufferedImage passwordOrder;
	private ImageIcon backButtonImage = new ImageIcon("back.png");
	private ImageIcon backButtonEnteredImage = new ImageIcon("backEntered.png");
	private ImageIcon exitButtonImage = new ImageIcon("exit.png");
	private ImageIcon exitButtonEnteredImage = new ImageIcon("exitEntered.png");
	private ImageIcon inputFinishButtonImage = new ImageIcon("inputFinish.png");
	private ImageIcon inputFinishButtonEnteredImage = new ImageIcon("inputFinishEntered.png");
	private ImageIcon koreanBackButtonImage = new ImageIcon("koreanBack.png");
	private ImageIcon koreanBackButtonEnteredImage = new ImageIcon("koreanBackEntered.png");
	private ImageIcon bigGomainButtonImage = new ImageIcon("bigGomain.png");
	private ImageIcon bigGomainButtonEnteredImage = new ImageIcon("bigGomainEntered.png");  // 버튼에 넣을 이미지아이콘을 만든다 
	
	public PasswordInputPanel() {
		
		try {
			placeOrder = ImageIO.read(new File("placeOrder.png"));
			passwordOrder = ImageIO.read(new File("passwordOrder.png"));
		}catch(IOException e) {};// 만든 버퍼드이미지에 이미지파일을 추가시킨다 
		 
		this.setLayout(null);  // 배치는 널로 
		fieldFont   = new Font("Serif",Font.PLAIN,17);   // 입력하는 필드 폰트 
		backButton = new JButton(backButtonImage);
		exitButton = new JButton(exitButtonImage);
		inputFinishButton = new JButton(inputFinishButtonImage);
		koreanBackButton = new JButton(koreanBackButtonImage);
		bigGomainButton = new JButton(bigGomainButtonImage);  // 컴포넌트에 이미지아이콘을 추가하고 생성
		passwordInputField = new JTextField(50);
		placeInputField = new JTextField(50);   // 텍스트필드 생성 
		
		backButton.setBorderPainted(false);
		backButton.setContentAreaFilled(false);
		backButton.setFocusPainted(false);
		backButton.setBounds(0,0,86,80);
		exitButton.setBorderPainted(false);
		exitButton.setContentAreaFilled(false);
		exitButton.setFocusPainted(false);
		exitButton.setBounds(width-100,0,86,80);
		inputFinishButton.setBorderPainted(false);
		inputFinishButton.setContentAreaFilled(false);
		inputFinishButton.setFocusPainted(false);
		inputFinishButton.setBounds(100,290,192,62);
		koreanBackButton.setBorderPainted(false);
		koreanBackButton.setContentAreaFilled(false);
		koreanBackButton.setFocusPainted(false);
		koreanBackButton.setBounds(300,290,192,62);
		placeInputField.setFont(fieldFont);
		placeInputField.setBounds(100,250,400,30);
		passwordInputField.setFont(fieldFont);
		passwordInputField.setBounds(100,250,400,30);
		bigGomainButton.setBorderPainted(false);
		bigGomainButton.setContentAreaFilled(false);
		bigGomainButton.setFocusPainted(false);
		bigGomainButton.setBounds(140,300,300,70);   // 컴포넌트들의 위치설정과 이미지 그대로 보여주게 하는 코드 
		
		
		backButton.addMouseListener(new MouseAdapter(){ // 좌측상단 뒤로가기 버튼에 대한 마우스 이벤트 
			public void mousePressed(MouseEvent e) {  // 클릭했을때  이벤트 
				if(inputScreen ==0) {    //  1번째 화면이면 메인패널로 돌아간다 
					inputBack = 1;
				    placeInputField.setText("");
				    passwordInputField.setText("");
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));  // 
				}
				if(inputScreen == 1) {  // 2번쨰 화면이면 1번쨰 화면으로 돌아간다 
					passwordInputField.setVisible(false);
					placeInputField.setVisible(true);
					inputFinishButton.setVisible(true);
					koreanBackButton.setVisible(true);
					bigGomainButton.setVisible(false);
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
					inputScreen = 0;
					}
				
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
		
		exitButton.addMouseListener(new MouseAdapter() {   // 우측상단 종료하기 버튼에 대한 마우스 이벤트 
			public void mousePressed(MouseEvent e) { // 클릭하면 종료 
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
		

		
		
		passwordInputField.addActionListener(e->{
			inputBack = 1;
			inputScreen = 0;
			bigGomainButton.setVisible(false);
			passwordInputField.setVisible(false);
			placeInputField.setVisible(true);
			koreanBackButton.setVisible(true);
			inputFinishButton.setVisible(true);  // 메인 화면으로 돌아가는 코드 
		    try {
				File outFile= new File("out.txt");
				if(!outFile.exists())outFile.createNewFile();
				BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));
				if(!passwordInputField.getText().equals("")) {
				if(placeInputField.getText().equals(""))
					bw.write("패스워드 : " + passwordInputField.getText());
				else bw.write("사용할 장소 : " + placeInputField.getText() +"    "+ "패스워드 : " + passwordInputField.getText());
				bw.newLine();
				bw.close();
				}
			} catch (IOException e1) {
				e1.printStackTrace();   // 입력한 내용들을 파일에 저장하는 코드 
			}
		    placeInputField.setText("");
		    passwordInputField.setText("");
		});

		placeInputField.addActionListener(e->{
			passwordInputField.setVisible(true);
			placeInputField.setVisible(false);
			koreanBackButton.setVisible(false);
			inputFinishButton.setVisible(false);
			bigGomainButton.setVisible(true);    // 2번쨰 화면으로 전환 
			inputScreen = 1;
		});

		inputFinishButton.addMouseListener(new MouseAdapter() {  // 입력완료 버튼 눌렀을 때 이벤트 처리 
			public void mousePressed(MouseEvent e) {
					passwordInputField.setVisible(true);
					placeInputField.setVisible(false);
					koreanBackButton.setVisible(false);
					inputFinishButton.setVisible(false);
					bigGomainButton.setVisible(true);    // 2번쨰 화면으로 전환 
					inputScreen = 1;
					inputFinishButton.setIcon(inputFinishButtonImage);
					inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));

			}
			@Override
			public void mouseEntered(MouseEvent e) {
				inputFinishButton.setIcon(inputFinishButtonEnteredImage);
				inputFinishButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {
				inputFinishButton.setIcon(inputFinishButtonImage);
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		
		koreanBackButton.addMouseListener(new MouseAdapter() {  // 뒤로가기 버튼에 대한 마우스 이벤트 처리 
			public void mousePressed(MouseEvent e) {
					inputBack = 1;    // 클릭하면 메인 패널로 돌아간다 
				    placeInputField.setText("");
				    passwordInputField.setText("");
					koreanBackButton.setIcon(koreanBackButtonImage);
					koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}

			public void mouseEntered(MouseEvent e) {
				koreanBackButton.setIcon(koreanBackButtonEnteredImage);
				koreanBackButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}

			public void mouseExited(MouseEvent e) {
				koreanBackButton.setIcon(koreanBackButtonImage);
				koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		

		bigGomainButton.addMouseListener(new MouseAdapter() {  // 파일에저장하고 메인패널로 돌아가는 버튼에 대한 마우스 이벤트 처리 
			public void mousePressed(MouseEvent e) {   // 클릭 했을 때 
				inputBack = 1;
				inputScreen = 0;
				bigGomainButton.setVisible(false);
				passwordInputField.setVisible(false);
				placeInputField.setVisible(true);
				koreanBackButton.setVisible(true);
				inputFinishButton.setVisible(true);  // 메인 화면으로 돌아가는 코드 
			    try {
			    	File outFile= new File("out.txt");
					if(!outFile.exists())outFile.createNewFile();
					BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));
					if(!passwordInputField.getText().equals("")) {
					if(placeInputField.getText().equals(""))
						bw.write("패스워드 : " + passwordInputField.getText());
					else bw.write("사용할 장소 : " + placeInputField.getText() +"    "+ "패스워드 : " + passwordInputField.getText());
					bw.newLine();
					bw.close();
					}
				} catch (IOException e1) {
					e1.printStackTrace();   // 입력한 내용들을 파일에 저장하는 코드 
				}
			    placeInputField.setText("");
			    passwordInputField.setText("");
			    bigGomainButton.setIcon(bigGomainButtonImage);
			    bigGomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
			@Override
			public void mouseEntered(MouseEvent e) {
				bigGomainButton.setIcon(bigGomainButtonEnteredImage);
				bigGomainButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {
				bigGomainButton.setIcon(bigGomainButtonImage);
				bigGomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		this.add(exitButton);
		this.add(backButton);
		this.add(koreanBackButton);
		this.add(inputFinishButton);
		this.add(placeInputField);
		this.add(passwordInputField);
		this.add(bigGomainButton);    //만든 컴포넌트들을 패널에 추가시킨다 	
		passwordInputField.setVisible(false);
		bigGomainButton.setVisible(false);   // 첫 화면에 보여질 필요 없는것들은 setVisible(false)로 한다 
	}
	
	
	
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		if(inputScreen == 0)   // 몇 번째 화면인지에 따라 보여지는 이미지를 바꾼다 
			g.drawImage(placeOrder, 100,150,null);
		if(inputScreen == 1)
			g.drawImage(passwordOrder,100,150,null);
		repaint();
		}
	
}
