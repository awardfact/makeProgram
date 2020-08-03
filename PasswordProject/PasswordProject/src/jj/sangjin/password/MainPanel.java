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
	protected int menu1 = 0;    // ������ư �������� �ٲ�� ����
	protected int menu2 = 0;    // �Է��ϱ� ��ư �������� �ٲ�� ����
	protected int menu3 = 0;    // �ҷ����� ��ư �������� �ٲ�� ����
	private static int width = 600;  // ȭ�� ũ��
	private static int height = 500;
	protected int count = 0;

	private JButton makeButton;      //������гη� �������� ��ư
	private JButton inputButton;   // �Է��ϱ� �І��� �������� ��ư
	private JButton outputButton;  // �ҷ����� �гη� �������� ��ư
	private JButton underExitButton;  //�ؿ��ִ� �����ϱ��ư
	private JButton exitButton;  // ������� �����ϱ� ��ư
	
	private ImageIcon makeButtonEnteredImage = new ImageIcon("makeEntered.png");
	private ImageIcon makeButtonImage = new ImageIcon("make.png");
	private ImageIcon inputButtonImage = new ImageIcon("input.png");
	private ImageIcon inputButtonEnteredImage = new ImageIcon("inputEntered.png");
	private ImageIcon outputButtonImage = new ImageIcon("output.png");
	private ImageIcon outputButtonEnteredImage = new ImageIcon("outputEntered.png");
	private ImageIcon underExitButtonImage = new ImageIcon("underExit.png");
	private ImageIcon underExitButtonEnteredImage = new ImageIcon("underExitEntered.png");
	private ImageIcon exitButtonImage = new ImageIcon("exit.png");
	private ImageIcon exitButtonEnteredImage = new ImageIcon("exitEntered.png");    // ���� png���� �̹��� ��ü�� ������ش�
	
	private JLabel appName1;
	private JLabel appName2;
	private JLabel appName3;
	private JLabel appName4;
	private JLabel appName5;
	private JLabel appName6;
	private JLabel appName7;
	
	private Font font = new Font("serif",Font.BOLD,30);
	
		public MainPanel() {
			
		this.setLayout(null);  // ���̾ƿ��� �η�
		makeButton = new JButton(makeButtonImage);
		inputButton = new JButton(inputButtonImage);
		outputButton = new JButton(outputButtonImage);
		underExitButton = new JButton(underExitButtonImage);
		exitButton = new JButton(exitButtonImage);  // �̹�����ü�� ��ư�� �־��ش�
		appName1 = new JLabel("��");
		appName2 = new JLabel("��");
		appName3 = new JLabel("��");
		appName4 = new JLabel("��");
		appName5 = new JLabel("��");
		appName6 = new JLabel("��");
		appName7 = new JLabel("��");
		appName1.setFont(font);
		appName2.setFont(font);
		appName3.setFont(font);
		appName4.setFont(font);
		appName5.setFont(font);
		appName6.setFont(font);
		appName7.setFont(font);
		
		

		makeButton.setBounds(200,150,190,60);   // ��ư ��ġ
		makeButton.setBorderPainted(false);   
		makeButton.setContentAreaFilled(false);
		makeButton.setFocusPainted(false);    // �� 3���� �̹��� �״�� ���̰� �ϱ� ���� �ڵ�
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
		

		
		makeButton.addMouseListener(new MouseAdapter() {   // �н����� ����� ��ư�� ���� ���콺 ������
				public void mousePressed(MouseEvent e) {   // Ŭ�� �� ȭ����ȯ�� ���� menu1�� 1�� �ٲٰ� ���콺 �÷���� �� �ٲ�� ���� �������´�
 					menu1 = 1;   
					makeButton.setIcon(makeButtonImage);
					makeButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
				@Override
				public void mouseEntered(MouseEvent e) {  // ���콺�� �ö󰡸� Ŀ���� �̹����� �ٲ�� 
					makeButton.setIcon(makeButtonEnteredImage);
					makeButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
				}
				@Override
				public void mouseExited(MouseEvent e) {  // ���콺�� �ٽ� ������ ������ ������� ���ƿ´�
					makeButton.setIcon(makeButtonImage);
					makeButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
		});
		
		inputButton.addMouseListener(new MouseAdapter() {// �н����� �Է��ϱ� ��ư�� ���� ���콺 ������
			public void mousePressed(MouseEvent e) {// Ŭ�� �� ȭ����ȯ�� ���� menu2�� 1�� �ٲٰ� ���콺 �÷���� �� �ٲ�� ���� �������´�
				menu2 = 1;
				inputButton.setIcon(inputButtonImage);
				inputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
			@Override
			public void mouseEntered(MouseEvent e) { // ���콺�� �ö󰡸� Ŀ���� �̹����� �ٲ�� 
				inputButton.setIcon(inputButtonEnteredImage);
				inputButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// ���콺�� �ٽ� ������ ������ ������� ���ƿ´�
				inputButton.setIcon(inputButtonImage);
				inputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
	});
	
		outputButton.addMouseListener(new MouseAdapter() {// �н����� �ҷ����� ��ư�� ���� ���콺 ������
			public void mousePressed(MouseEvent e) {// Ŭ�� �� ȭ����ȯ�� ���� menu3�� 1�� �ٲٰ� ���콺 �÷���� �� �ٲ�� ���� �������´�
				menu3 = 1;
				outputButton.setIcon(outputButtonImage);
				outputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
			@Override
			public void mouseEntered(MouseEvent e) { // ���콺�� �ö󰡸� Ŀ���� �̹����� �ٲ�� 
				outputButton.setIcon(outputButtonEnteredImage);
				outputButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// ���콺�� �ٽ� ������ ������ ������� ���ƿ´�
				outputButton.setIcon(outputButtonImage);
				outputButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
	});
		
		underExitButton.addMouseListener(new MouseAdapter() {// �н����� �����ϱ� ��ư�� ���� ���콺 ������
			public void mousePressed(MouseEvent e) {  // ������ ���α׷��� ����ȴ� 
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) { // ���콺�� �ö󰡸� Ŀ���� �̹����� �ٲ�� 
				underExitButton.setIcon(underExitButtonEnteredImage);
				underExitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {	 // ���콺�� �ٽ� ������ ������ ������� ���ƿ´�
				underExitButton.setIcon(underExitButtonImage);
				underExitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
	});
		
		
		exitButton.addMouseListener(new MouseAdapter() {// ������� �н����� �����ϱ� ��ư�� ���� ���콺 ������
			public void mousePressed(MouseEvent e) {// ������ ���α׷��� ����ȴ� 
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) {// ���콺�� �ö󰡸� Ŀ���� �̹����� �ٲ�� 
				exitButton.setIcon(exitButtonEnteredImage);
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// ���콺�� �ٽ� ������ ������ ������� ���ƿ´�
				exitButton.setIcon(exitButtonImage);
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		this.add(makeButton);
		this.add(inputButton);
		this.add(outputButton);
		this.add(underExitButton);
		this.add(exitButton);   // ��ư���� �гο� �߰����ش� 
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
