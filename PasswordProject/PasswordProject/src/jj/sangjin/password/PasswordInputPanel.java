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
	private int inputScreen  = 0;  // �г��� ���° ȭ������ ��Ÿ���� ���� 
	
	private JButton backButton;
	private JButton exitButton;
	private JButton inputFinishButton;
	private JButton koreanBackButton;
	private JButton bigGomainButton;
	private JTextField placeInputField;
	private JTextField passwordInputField;
	private Font fieldFont;      // �Է��ϱ� �гο� �ʿ��� ������Ʈ���� ����� 
	protected int inputBack = 0;   // 1�̵Ǹ� �����гη� ���ư��� ���� 
	
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
	private ImageIcon bigGomainButtonEnteredImage = new ImageIcon("bigGomainEntered.png");  // ��ư�� ���� �̹����������� ����� 
	
	public PasswordInputPanel() {
		
		try {
			placeOrder = ImageIO.read(new File("placeOrder.png"));
			passwordOrder = ImageIO.read(new File("passwordOrder.png"));
		}catch(IOException e) {};// ���� ���۵��̹����� �̹��������� �߰���Ų�� 
		 
		this.setLayout(null);  // ��ġ�� �η� 
		fieldFont   = new Font("Serif",Font.PLAIN,17);   // �Է��ϴ� �ʵ� ��Ʈ 
		backButton = new JButton(backButtonImage);
		exitButton = new JButton(exitButtonImage);
		inputFinishButton = new JButton(inputFinishButtonImage);
		koreanBackButton = new JButton(koreanBackButtonImage);
		bigGomainButton = new JButton(bigGomainButtonImage);  // ������Ʈ�� �̹����������� �߰��ϰ� ����
		passwordInputField = new JTextField(50);
		placeInputField = new JTextField(50);   // �ؽ�Ʈ�ʵ� ���� 
		
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
		bigGomainButton.setBounds(140,300,300,70);   // ������Ʈ���� ��ġ������ �̹��� �״�� �����ְ� �ϴ� �ڵ� 
		
		
		backButton.addMouseListener(new MouseAdapter(){ // ������� �ڷΰ��� ��ư�� ���� ���콺 �̺�Ʈ 
			public void mousePressed(MouseEvent e) {  // Ŭ��������  �̺�Ʈ 
				if(inputScreen ==0) {    //  1��° ȭ���̸� �����гη� ���ư��� 
					inputBack = 1;
				    placeInputField.setText("");
				    passwordInputField.setText("");
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));  // 
				}
				if(inputScreen == 1) {  // 2���� ȭ���̸� 1���� ȭ������ ���ư��� 
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
		
		exitButton.addMouseListener(new MouseAdapter() {   // ������� �����ϱ� ��ư�� ���� ���콺 �̺�Ʈ 
			public void mousePressed(MouseEvent e) { // Ŭ���ϸ� ���� 
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
			inputFinishButton.setVisible(true);  // ���� ȭ������ ���ư��� �ڵ� 
		    try {
				File outFile= new File("out.txt");
				if(!outFile.exists())outFile.createNewFile();
				BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));
				if(!passwordInputField.getText().equals("")) {
				if(placeInputField.getText().equals(""))
					bw.write("�н����� : " + passwordInputField.getText());
				else bw.write("����� ��� : " + placeInputField.getText() +"    "+ "�н����� : " + passwordInputField.getText());
				bw.newLine();
				bw.close();
				}
			} catch (IOException e1) {
				e1.printStackTrace();   // �Է��� ������� ���Ͽ� �����ϴ� �ڵ� 
			}
		    placeInputField.setText("");
		    passwordInputField.setText("");
		});

		placeInputField.addActionListener(e->{
			passwordInputField.setVisible(true);
			placeInputField.setVisible(false);
			koreanBackButton.setVisible(false);
			inputFinishButton.setVisible(false);
			bigGomainButton.setVisible(true);    // 2���� ȭ������ ��ȯ 
			inputScreen = 1;
		});

		inputFinishButton.addMouseListener(new MouseAdapter() {  // �Է¿Ϸ� ��ư ������ �� �̺�Ʈ ó�� 
			public void mousePressed(MouseEvent e) {
					passwordInputField.setVisible(true);
					placeInputField.setVisible(false);
					koreanBackButton.setVisible(false);
					inputFinishButton.setVisible(false);
					bigGomainButton.setVisible(true);    // 2���� ȭ������ ��ȯ 
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
		
		
		
		koreanBackButton.addMouseListener(new MouseAdapter() {  // �ڷΰ��� ��ư�� ���� ���콺 �̺�Ʈ ó�� 
			public void mousePressed(MouseEvent e) {
					inputBack = 1;    // Ŭ���ϸ� ���� �гη� ���ư��� 
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
		

		bigGomainButton.addMouseListener(new MouseAdapter() {  // ���Ͽ������ϰ� �����гη� ���ư��� ��ư�� ���� ���콺 �̺�Ʈ ó�� 
			public void mousePressed(MouseEvent e) {   // Ŭ�� ���� �� 
				inputBack = 1;
				inputScreen = 0;
				bigGomainButton.setVisible(false);
				passwordInputField.setVisible(false);
				placeInputField.setVisible(true);
				koreanBackButton.setVisible(true);
				inputFinishButton.setVisible(true);  // ���� ȭ������ ���ư��� �ڵ� 
			    try {
			    	File outFile= new File("out.txt");
					if(!outFile.exists())outFile.createNewFile();
					BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));
					if(!passwordInputField.getText().equals("")) {
					if(placeInputField.getText().equals(""))
						bw.write("�н����� : " + passwordInputField.getText());
					else bw.write("����� ��� : " + placeInputField.getText() +"    "+ "�н����� : " + passwordInputField.getText());
					bw.newLine();
					bw.close();
					}
				} catch (IOException e1) {
					e1.printStackTrace();   // �Է��� ������� ���Ͽ� �����ϴ� �ڵ� 
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
		this.add(bigGomainButton);    //���� ������Ʈ���� �гο� �߰���Ų�� 	
		passwordInputField.setVisible(false);
		bigGomainButton.setVisible(false);   // ù ȭ�鿡 ������ �ʿ� ���°͵��� setVisible(false)�� �Ѵ� 
	}
	
	
	
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		if(inputScreen == 0)   // �� ��° ȭ�������� ���� �������� �̹����� �ٲ۴� 
			g.drawImage(placeOrder, 100,150,null);
		if(inputScreen == 1)
			g.drawImage(passwordOrder,100,150,null);
		repaint();
		}
	
}
